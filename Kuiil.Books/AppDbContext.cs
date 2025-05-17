using System;
using Microsoft.EntityFrameworkCore;

namespace Kuiil.Books;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set;}
}
