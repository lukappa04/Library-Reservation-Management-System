using WebionLibraryAPI.DTO.BookDto.DeleteBookDto;
using WebionLibraryAPI.Models.Books;

namespace WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;

public interface IBookRepository
{
    Task<List<BookM>> GetAllBooksAsync();
    Task<BookM?> GetBookByIdAsync(int id);
    Task<BookM?> GetBookByTitleAsync(string Title);
    Task AddBookAsync(BookM book);
    Task UpdateBookAsync(int id, BookM book);
    Task DeleteBookAsync(BookM bookM);
    Task<bool> IsIsbnExistsAsync(string isbn);
}