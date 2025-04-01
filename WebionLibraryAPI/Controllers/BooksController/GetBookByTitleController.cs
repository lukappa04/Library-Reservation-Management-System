using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.BookDto.GetBookByTitleDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;

    /// <summary>
    /// Questo controller si dedica all trovare un libro tramite il proprio title
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookByTitleController : ControllerBase
    {
        private readonly IBookService _bookService;
        public GetBookByTitleController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// L'endpoint che riceve il titolo come parametro e se il titolo esiste richiama il metodo "GetBookByTitleAsync" per andare a pescare i dati dell'intero libro
        /// </summary>
        /// <param name="title">campo per identificare il libro da trovare</param>
        /// <returns>Ok se il libro viene trovato /  NotFound se il libro non viene trovato</returns>

        [HttpGet("{title}")]
        public async Task<IActionResult> GetBookById(string title)
        {
            var request = new GetBookByTitleRequestDto {title = title};
            var book = await _bookService.GetBookByTitleAsync(request);
            return book is not null ? Ok(book) : NotFound();
        }
    }

