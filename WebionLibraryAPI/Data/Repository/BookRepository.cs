using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebionLibraryAPI.Data.LibDbContext;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.DTO.BookDto.UpdateBookDto;
using WebionLibraryAPI.Models.Books;

namespace WebionLibraryAPI.Data.Repository;

public class BookRepository : IBookRepository
{
    private readonly IMemoryCache _cache;
    private readonly LibraryDbContext _context;
    private const string CacheKey = "books_cache_KEY";

    public BookRepository(LibraryDbContext context, IMemoryCache cache)
    {
        _context = context; 
        _cache = cache;  
    }
    public async Task AddBookAsync(BookM book)
    {
       //_context.Books.Add(book);
       //await _context.SaveChangesAsync();
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
       _cache.Remove(CacheKey);
    }

    public async Task DeleteBookAsync(BookM book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        _cache.Remove(CacheKey);
    }

    public async Task<List<BookM>> GetAllBooksAsync()
    {
        if(_cache.TryGetValue(CacheKey, out List<BookM> books))
        {
            return books;
        }
        var bookdb = await _context.Books.ToListAsync();
        _cache.Set(CacheKey, bookdb, TimeSpan.FromMinutes(10));
        return bookdb;
        //return await _context.Books.ToListAsync();
    }

    public async Task<BookM?> GetBookByIdAsync(int id)
    {
        //return await _context.Books.FindAsync(id);
        var books = await GetAllBooksAsync();
        return books.FirstOrDefault(b=> b.Id == id);
    }

    public async Task<List<BookM?>> GetBookByTitleAsync(string Title)
    {
        //return await _context.Books.FirstOrDefaultAsync(b => b.Title == Title);
        var books = await GetAllBooksAsync();
        return books
        .Where(b => b.Title.Equals(Title, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }

    public async Task UpdateBookAsync(int id, BookM book)
    {
        var existingBook = await _context.Books.FindAsync(id);
        if (existingBook is null) throw new KeyNotFoundException($"Book with ID {id} not found.");

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.ISBN = book.ISBN;
        existingBook.Status = book.Status;

        await _context.SaveChangesAsync();
        _cache.Remove(CacheKey);
    }

    public async Task<bool> IsIsbnExistsAsync(string isbn)
    {
        var books = await GetAllBooksAsync();
        return books.Any(b => b.ISBN == isbn);
    }

    public async Task<List<BookM?>> GetBookByAuthorAsync(string Author)
    {
        var books = await GetAllBooksAsync();
        return books
        .Where(b => b.Author.Equals(Author, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }
}