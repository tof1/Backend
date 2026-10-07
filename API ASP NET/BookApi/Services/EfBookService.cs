using BookApi.Data;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Services;

public class EfBookService : IBookService
{
    private readonly AppDbContext _db;

    public EfBookService(AppDbContext db) => _db = db;

    public IEnumerable<Book> GetAll() =>
        _db.Books.AsNoTracking().ToList();

    public Book? GetById(int id) =>
        _db.Books.Find(id);

    public Book Create(Book book0)
    {
        book0.Id = 0; // let SQL Server generate the Id
        _db.Books.Add(book0);
        _db.SaveChanges();
        return book0;
    }

    public bool Update(int id, Book updated)
    {
        var book = _db.Books.Find(id);
        if (book is null) return false;

        book.Title = updated.Title;
        book.Author = updated.Author;
        book.Year = updated.Year;

        _db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var book = _db.Books.Find(id);
        if (book is null) return false;

        _db.Books.Remove(book);
        _db.SaveChanges();
        return true;
    }
}