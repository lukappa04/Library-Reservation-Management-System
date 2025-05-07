using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.BookDto.AddBookDto;
using WebionLibraryAPI.Exceptions;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;
    /// <summary>
    /// Controller responsabile dell'aggiunta di un nuovo libro alla libreria.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    [Tags("Books")]
    public class AddBookController : ControllerBase
    {
        /// <summary>
        /// Costruttore per iniettare IBookService.
        /// </summary>
        private readonly IBookService _bookService;
        public AddBookController(IBookService bookService)
        {
            _bookService = bookService;    
        }
        /// <summary>
        /// Aggiunge un nuovo libro alla libreria.
        /// </summary>
        /// <param name="request">I dati del libro da aggiungere.</param>
        /// <returns>200: Libro aggiunto con successo.</returns>
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookRequestDto request)
        {
            try{
            var book = await _bookService.AddBookAsync(request);
            return book is not null ? Ok(book) : NotFound();
            }catch(DataAlreadyExistExc)
            {
                return BadRequest("ISBN già esistente");
            }
        }
    }

