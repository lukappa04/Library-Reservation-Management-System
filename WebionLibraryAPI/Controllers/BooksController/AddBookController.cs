using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.BookDto.AddBookDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;

    [Route("api/[controller]")]
    [ApiController]
    public class AddBookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public AddBookController(IBookService bookService)
        {
            _bookService = bookService;    
        }
        // POST: api/Book
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookRequestDto request)
        {
            var book = await _bookService.AddBookAsync(request);
            return Ok(book);
        }
    }

