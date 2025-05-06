using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.Service;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;

    /// <summary>
    /// Controller responsabile del recupero di tutti i libri.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Books")]
    public class GetAllBooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        /// <summary>
        /// Inizializza una nuova istanza del <see cref="GetAllBooksController"/>.
        /// </summary>
        /// <param name="bookService">Servizio per la gestione dei libri.</param>
        public GetAllBooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// Recupera la lista completa di tutti i libri presenti nel sistema.
        /// </summary>
        /// <returns>Una lista di libri.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBookAsync();
            return Ok(books);
        }
    }

