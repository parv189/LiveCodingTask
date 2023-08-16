using Author_Books_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Author_Books_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AuthorBookContext _authorBookContext;

        public BooksController(AuthorBookContext authorBookContext)
        {
            _authorBookContext = authorBookContext;
        }

        [HttpGet]
        public async Task<IActionResult> Getdata()
        {
            var x = _authorBookContext.BooksDataDto.FromSqlRaw("exec usp_Booksdata");
            return Ok(x);

        }
        [HttpGet("LinkQ")]
        public async Task<IActionResult> GetdatawithLinkQ()
        {
            var booksData = _authorBookContext.Books
                .Join(_authorBookContext.AuthorBooks,
                b => b.AuthorBookId, ab => ab.BookId,
                (b, ab) => new { Book = b, AuthorBook = ab })
                .Join(_authorBookContext.Authors,
                ab => ab.AuthorBook.AuthorId, a => a.AuthorBookId,
                (ab, a) => new { AuthorBook = ab, Author = a })
                .GroupBy(
                ba => new { ba.AuthorBook.Book.BookID, ba.AuthorBook.Book.Bookname, ba.AuthorBook.Book.BookPrice,ba.AuthorBook.Book.PublicationDate },
                //ba => ba.AuthorBook.Book.BookID,
                (key, value) => new {
                    bookID = key.BookID,
                    bookname = key.Bookname,
                    bookPrice = key.BookPrice,
                    publicationDate = key.PublicationDate,
                    authorsName = string.Join(',', value.Select(
                    a => a.Author.AuthorName))
                
                }).ToList();
            return Ok(booksData);

        }
    }
}
