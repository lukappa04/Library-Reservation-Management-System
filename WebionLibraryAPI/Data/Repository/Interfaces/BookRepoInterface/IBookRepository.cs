using WebionLibraryAPI.DTO.BookDto.DeleteBookDto;
using WebionLibraryAPI.Models.Books;

namespace WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
/// <summary>
/// Interfaccia per la gestione del repository dei libri.
/// Definisce le operazioni CRUD e di ricerca.
/// </summary>
public interface IBookRepository
{
    Task<List<BookM>> GetAllBooksAsync();
    Task<BookM?> GetBookByIdAsync(int id);
    Task<List<BookM?>> GetBookByTitleAsync(string Title);
    Task<List<BookM?>> GetBookByAuthorAsync(string Author);
    Task AddBookAsync(BookM book);
    Task UpdateBookAsync(int id, BookM book);
    Task DeleteBookAsync(BookM bookM);
    Task<bool> IsIsbnExistsAsync(string isbn);
}