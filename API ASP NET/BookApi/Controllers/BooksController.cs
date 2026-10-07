using BookApi.Dtos;
using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BookDto>> GetAll()
    {
        var books = _bookService.GetAll().Select(ToDto);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public ActionResult<BookDto> GetById(int id)
    {
        Book? book = _bookService.GetById(id);
        if (book == null) return NotFound();

        return Ok(ToDto(book));
    }

    [HttpPost]
    public ActionResult<BookDto> Create(CreateBookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Year = dto.Year
        };

        var created = _bookService.Create(book);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, ToDto(created));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateBookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Year = dto.Year
        };

        bool updated = _bookService.Update(id, book);
        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _bookService.Delete(id);
        if (!deleted) return NotFound();

        return NoContent();
    }

    private static BookDto ToDto(Book book) => new()
    {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        Year = book.Year
    };
}