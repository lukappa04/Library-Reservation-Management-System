using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.BookDto.DeleteBookDto;

public sealed class DeleteBookRequestDto
{
    [Required]
    public int Id { get; set; }
}