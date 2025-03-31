using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.BookDto.GetBookByIdDto;

public sealed class GetBookByIdRequestDto
{
    [Required]
    public int id { get; set; }
}