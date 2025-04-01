using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.BookDto.GetBookByIdDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;

    /// <summary>
    /// Questo controller si dedica all trovare un libro tramite il proprio id
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookByIdController : ControllerBase
    {
        private readonly IBookService _bookService;
        public GetBookByIdController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// L'endpoint che riceve l'id come parametro e se l'id esiste richiama il metodo "GetBookByIdAsync" per andare a pescare i dati dell'intero libro
        /// </summary>
        /// <param name="id">campo per identificare il libro da trovare</param>
        /// <returns>Ok se il libro viene trovato /  NotFound se il libro non viene trovato</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var request = new GetBookByIdRequestDto {id = id};
            var book = await _bookService.GetBookByIdAsync(request);
            return book is not null ? Ok(book) : NotFound();
        }
    }

