namespace Kuiil.Books;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public List<string> Author { get; set; } = [];

    public int Year { get; set; }
}
