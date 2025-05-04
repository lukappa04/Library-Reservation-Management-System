using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.BookDto.GetBookByAuthor;

public class GetBookByAuthorRequestDto
{
    [Required]
    public string Author { get; set; } = string.Empty;
}