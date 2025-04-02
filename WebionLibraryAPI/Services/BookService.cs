using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.DTO.BookDto;
using WebionLibraryAPI.DTO.BookDto.AddBookDto;
using WebionLibraryAPI.DTO.BookDto.DeleteBookDto;
using WebionLibraryAPI.DTO.BookDto.GetBookByIdDto;
using WebionLibraryAPI.DTO.BookDto.GetBookByTitleDto;
using WebionLibraryAPI.DTO.BookDto.UpdateBookDto;
using WebionLibraryAPI.Models.Books;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Service;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookResponseDto> AddBookAsync(AddBookRequestDto request)
    {
        BookM newBook = new BookM
        {
            Title = request.Title,
            Author = request.Author,
            ISBN = request.ISBN,
            Status = request.Status
        };

        await _bookRepository.AddBookAsync(newBook);
        return new BookResponseDto(newBook);
    }

    public async Task<bool> DeleteBookAsync(DeleteBookRequestDto request)
    {
        BookM? book = await _bookRepository.GetBookByIdAsync(request.Id);
        if (book == null) return false; // Se il libro non esiste, ritorna false

        await _bookRepository.DeleteBookAsync(book);
        return true;
    }


    public async Task<IEnumerable<BookResponseDto>> GetAllBookAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        return books.Select(book => new BookResponseDto(book));
    }

    public async Task<BookResponseDto?> GetBookByIdAsync(GetBookByIdRequestDto request)
    {
        var book = await _bookRepository.GetBookByIdAsync(request.id);
        return book is not null ? new BookResponseDto(book) : null;
    }

    public async Task<BookResponseDto?> GetBookByTitleAsync(GetBookByTitleRequestDto request)
    {
        var book = await _bookRepository.GetBookByTitleAsync(request.title);
        return book is not null ? new BookResponseDto(book) : null;
    }

    public async Task<BookResponseDto> UpdateBookAsync(int id, UpdateBookRequestDto request)
    {
        BookM updateBook = await _bookRepository.GetBookByIdAsync(id);
        if(updateBook is null) throw new KeyNotFoundException("Libro non trovato");
        
        if (!string.IsNullOrEmpty(request.Title)) 
        updateBook.Title = request.Title ?? updateBook.Title;

        if (!string.IsNullOrEmpty(request.Author)) 
            updateBook.Author = request.Author ?? updateBook.Author;

        if (!string.IsNullOrEmpty(request.ISBN)) 
            updateBook.ISBN = request.ISBN ?? updateBook.ISBN;

        if (request.Status != updateBook.Status) 
            updateBook.Status = request.Status;

        await _bookRepository.UpdateBookAsync(id, updateBook);
        return new BookResponseDto(updateBook);
    }
}