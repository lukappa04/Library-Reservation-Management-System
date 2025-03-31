using WebionLibraryAPI.Data.Enum;
using WebionLibraryAPI.Models.Books;

namespace WebionLibraryAPI.DTO.BookDto.GetBookByTitleDto;

public sealed class BookResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public BooksStatusE Status {get; set;} = BooksStatusE.Available;

    public BookResponseDto(BookM bookM)
    {
        Id = bookM.Id;
        Title = bookM.Title;
        Author = bookM.Author;
        ISBN = bookM.ISBN;
        Status = bookM.Status;
    }
}