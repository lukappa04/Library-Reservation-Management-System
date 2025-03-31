using WebionLibraryAPI.Data.Enum;

namespace WebionLibraryAPI.DTO.BookDto.AddBookDto;

public sealed class AddBookRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public BooksStatusE Status {get; set;} = BooksStatusE.Available;
}