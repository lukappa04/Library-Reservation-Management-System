using Microsoft.EntityFrameworkCore;
using WebionLibraryAPI.Data.LibDbContext;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
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

    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if(book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    public Task DeleteBookAsync(BookM book)
    {
        throw new NotImplementedException();
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
        return await _context.Books.FindAsync(Title);
    }

    public async Task UpdateBookAsync(BookM book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }
}