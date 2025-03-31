using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.Service;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.BooksController;

    [Route("api/[controller]")]
    [ApiController]
    public class GetAllBooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public GetAllBooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        //Get
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBookAsync();
            return Ok(books);
        }
    }

