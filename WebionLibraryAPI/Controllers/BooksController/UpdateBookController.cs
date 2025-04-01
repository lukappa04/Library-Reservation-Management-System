using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.DTO.BookDto.UpdateBookDto;
using WebionLibraryAPI.Models.Books;
using WebionLibraryAPI.Service;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;
    /// <summary>
    /// Questo controller si dedica all apportare modifiche al libro selezionato
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public UpdateBookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// L'endpoint che riceve l'id come parametro e se l'id esiste richiama il metodo "UpdateBookAsync" per andare a portare i dati a schermo e mdoficare i dati richiesti
        /// </summary>
        /// <param name="id">campo per identificare il libro da trovare</param>
        /// <param name="request">il campo che porta tutti i campi da compilare per soddisfare la richiesta</param>
        /// <returns>Ok se il libro viene trovato /  NotFound se il libro non viene trovato</returns>

        //TODO: UpdateBook BUG da sistemare, guardare le issue
        [HttpPost]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookRequestDto request)
        {
            try{

            var book = await _bookService.UpdateBookAsync(id, request);
            return book is not null ? Ok(book) : NotFound();
            }catch(KeyNotFoundException)
            {
                return BadRequest("Id not found");
            }
        }
    }

