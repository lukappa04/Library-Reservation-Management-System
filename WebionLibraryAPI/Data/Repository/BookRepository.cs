using Microsoft.EntityFrameworkCore;
using WebionLibraryAPI.Data.LibDbContext;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.DTO.BookDto.UpdateBookDto;
using WebionLibraryAPI.Models.Books;

namespace WebionLibraryAPI.Data.Repository;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
    {
        _context = context;   
    }
    public async Task AddBookAsync(BookM book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(BookM book)
    {
        if(book.Id != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return;
        }
        //TODO: implementare eccezioni personalizzate
        throw new Exception("This book does not exist");
    }

    public async Task<IEnumerable<BookM>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<BookM?> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<BookM?> GetBookByTitleAsync(string Title)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Title == Title);
    }

    public async Task UpdateBookAsync(int id, BookM book)
    {
        var existingBook = await _context.Books.FindAsync(id);
        if (existingBook == null)
        {
            throw new KeyNotFoundException($"Book with ID {id} not found.");
        }

        // Aggiorna solo i campi necessari
        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.ISBN = book.ISBN;
        existingBook.Status = book.Status;

        await _context.SaveChangesAsync();
    }

}