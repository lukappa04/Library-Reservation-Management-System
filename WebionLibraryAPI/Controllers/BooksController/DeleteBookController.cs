using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.BookDto.DeleteBookDto;
using WebionLibraryAPI.Exceptions;
using WebionLibraryAPI.Models.Books;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;

    /// <summary>
    /// questo controller si dedica all'eliminazione di un singolo libro
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Books")]
    public class DeleteBookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public DeleteBookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// L'endpoint che riceve un id di un libro come parametro e tramite DeleteBookAsync se l'id viene trovato va ad eseguire il metodo che permette l'eliminazione dell'intero libro.
        /// </summary>
        /// <param name="id">campo per identificare il libro da eliminare</param>
        /// <returns> NoContent --> se tutto va bene / NotFound --> se il libro non viene trovato </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try{
                var request = new DeleteBookRequestDto { Id = id };
                var result = await _bookService.DeleteBookAsync(request);
                return result ? NoContent() : NotFound();
            }catch(DataNotFoundExc ex)
            {
                return NotFound(new{message = ex.Message});
            }
        }
    }

