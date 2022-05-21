using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookNetWebAPI.Dtos;
using BookNetWebAPI.Data;
using BookNetWebAPI.Models;

namespace BookNetWebAPI.Controllers;
    [ApiController]
    [Route("[controller]")]
    public class LibraryController:ControllerBase
    {
        private ILibrary _LibraryProvider;
        public LibraryController(ILibrary libraryProvider)
        {
            _LibraryProvider = libraryProvider;
        }

        [HttpGet]
        [Route("Books")]
        public ActionResult<ICollection<BookDTO>> GetBooks(){
            var bookList = _LibraryProvider.GetBooks().Select(x=>ConvertBooktoDTO(x)).ToList();
            return bookList;
        }

        [HttpGet("Books/{bookid}")]
        public ActionResult<BookDTO> GetBookById(int bookid){
            var book = ConvertBooktoDTO(_LibraryProvider.GetBookById(bookid));
            if(book == null)
                return NotFound();
            else
                return book;
        }

        [HttpGet]
        [Route("Authors")]
        public ActionResult<ICollection<AuthorDTO>> GetAuthors(){
            var authorList = _LibraryProvider.GetAuthors().Select(x=>ConvertAuthortoDTO(x)).ToList();
            return authorList;
        }

        [HttpGet("Authors/{authorid}")]
        public ActionResult<AuthorDTO> GetAuthorById(int authorid){
            var author = ConvertAuthortoDTO(_LibraryProvider.GetAuthorById(authorid));
            if(author == null)
                return NotFound();
            else
                return author;
        }

        [HttpGet]
        [Route("Sync")]
        public async Task<ActionResult> SyncDB(){
            await _LibraryProvider.SyncDataBase();
            return NoContent();
        }

        private BookDTO ConvertBooktoDTO(Book book){
            return new BookDTO{
                 id = book.BookId,
                 title = book.Title,
                 description = book.Description,
                 pagecount = book.PageCount,
                 excerpt = book.Excerpt,
                 publishdate = book.PublishDate,
                 urlcoverimage = book.UrlCoverImage,
                 authors = book.Authors.Select(x=>x.AuthorId).ToList()
            };
        }

        private AuthorDTO ConvertAuthortoDTO(Author author){
            return new AuthorDTO{
                id = author.AuthorId,
                firstName = author.FirstName,
                lastName = author.LastName,
                books = author.Books.Select(x=>x.BookId).ToList()
            };
        }
    }
