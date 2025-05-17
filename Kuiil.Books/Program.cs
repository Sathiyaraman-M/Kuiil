using Kuiil.Books;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("kuiil");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.AddServiceDefaults();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/books", async (AppDbContext dbContext) => await dbContext.Books.ToListAsync());

app.MapGet("/books/{id}", async (Guid id, AppDbContext dbContext) =>
{
    var book = await dbContext.Books.FindAsync(id);
    return book == null ? Results.NotFound() : Results.Ok(book);
});

app.MapPost("/books", async (Book book, AppDbContext dbContext) =>
{
    await dbContext.Books.AddAsync(book);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPut("/books/{id}", async (Guid id, Book book, AppDbContext dbContext) =>
{
    var existingBook = await dbContext.Books.FindAsync(id);
    if (existingBook == null)
    {
        return Results.NotFound();
    }
    existingBook.Title = book.Title;
    existingBook.Author = book.Author;
    existingBook.Year = book.Year;
    dbContext.Books.Update(existingBook);
    await dbContext.SaveChangesAsync();
    return Results.Ok(existingBook);
});

app.MapDelete("/books/{id}", async (Guid id, AppDbContext dbContext) =>
{
    var book = await dbContext.Books.FindAsync(id);
    if (book == null)
    {
        return Results.NotFound();
    }
    dbContext.Books.Remove(book);
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

await app.Services.CreateScope().ServiceProvider
    .GetRequiredService<AppDbContext>()
    .Database.MigrateAsync();

await app.RunAsync();
