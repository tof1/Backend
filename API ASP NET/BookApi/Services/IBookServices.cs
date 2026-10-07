using BookApi.Models;

namespace BookApi.Services;

public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    Book Create(Book book0);
    bool Update(int id, Book updated);
    bool Delete(int id);
}
