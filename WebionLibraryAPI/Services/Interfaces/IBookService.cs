using WebionLibraryAPI.DTO.BookDto;
using WebionLibraryAPI.DTO.BookDto.AddBookDto;
using WebionLibraryAPI.DTO.BookDto.DeleteBookDto;
using WebionLibraryAPI.DTO.BookDto.GetBookByIdDto;
using WebionLibraryAPI.DTO.BookDto.GetBookByTitleDto;
using WebionLibraryAPI.DTO.BookDto.UpdateBookDto;

namespace WebionLibraryAPI.Service.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookResponseDto>> GetAllBookAsync();
    Task<BookResponseDto?> GetBookByIdAsync(GetBookByIdRequestDto request);
    Task<BookResponseDto?> GetBookByTitleAsync(GetBookByTitleRequestDto request);
    Task<BookResponseDto> AddBookAsync(AddBookRequestDto request);
    Task<BookResponseDto> UpdateBookAsync(int id, UpdateBookRequestDto request);
    Task<bool> DeleteBookAsync(DeleteBookRequestDto request);
}