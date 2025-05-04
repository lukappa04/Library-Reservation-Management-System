using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.BookDto.GetBookByAuthor;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;

    [Route("api/[controller]")]
    [ApiController]
    [Tags("Books")]
    public class GetBookByAuthorController : ControllerBase
    {
        private readonly IBookService _bookService;
        public GetBookByAuthorController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// L'endpoint che riceve l'autore come parametro e se il titolo esiste richiama il metodo "GetBookByAuthorAsync" per andare a pescare i dati dell'intero libro
        /// </summary>
        /// <param name="author">campo per identificare il libro da trovare</param>
        /// <returns>Ok se il libro viene trovato /  NotFound se il libro non viene trovato</returns>

        [HttpGet("{author}")]
        public async Task<IActionResult> GetBookByAuthor(string author)
        {
            var request = new GetBookByAuthorRequestDto {Author = author};
            var book = await _bookService.GetBookByAuthorAsync(request);
            return book is not null ? Ok(book) : NotFound();
        }
    }

