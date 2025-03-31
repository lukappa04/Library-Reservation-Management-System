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

            //TODO: Da ricontrollare la CreatedAction. Rilascia un 500 internal server error per un routing sbagliato, ma comunque crea il libro.
            // Restituisce una risposta 201 Created con l'URL del libro appena creato
            return CreatedAtAction(nameof(GetAllBooksController.GetAllBooks), new { id = book.Id }, book);
        }
    }

