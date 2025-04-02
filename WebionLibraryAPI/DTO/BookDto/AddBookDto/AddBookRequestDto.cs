using System.ComponentModel.DataAnnotations;
using WebionLibraryAPI.Data.Enum;
using WebionLibraryAPI.DataChecker.BookDataChecker;

namespace WebionLibraryAPI.DTO.BookDto.AddBookDto;

public sealed class AddBookRequestDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    [ISBNDataChecker]
    public string ISBN { get; set; } = string.Empty;
    [Required]
    public BooksStatusE Status {get; set;} = BooksStatusE.Available;
}