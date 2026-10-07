using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos;

public class UpdateBookDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    [Range(1000, 2100)]
    public int Year { get; set; }
}