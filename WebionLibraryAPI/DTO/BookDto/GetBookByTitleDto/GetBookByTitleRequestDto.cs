using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.BookDto.GetBookByTitleDto;

public class GetBookByTitleRequestDto
{
    [Required]
    public string title { get; set; } = string.Empty;
}