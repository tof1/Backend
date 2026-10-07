using BookApi.Models;
using System.Linq;

namespace BookApi.Services;

public class InMemoryBookService : IBookService
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public Book Create(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
        return book;
    }

    public bool Update(int id, Book updated)
    {
        Book? existing = GetById(id);
        if (existing == null) return false;

        existing.Title = updated.Title;
        existing.Author = updated.Author;
        existing.Year = updated.Year;
        return true;
    }

    public bool Delete(int id)
    {
        Book? existing = GetById(id);
        if (existing == null) return false;

        _books.Remove(existing);
        return true;
    }
}