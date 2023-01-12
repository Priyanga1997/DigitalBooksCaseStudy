using AuthorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthorAPI.Models;

namespace AuthorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DigitalBooksContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        IAuthor _author;
        public AuthorController(DigitalBooksContext db, IWebHostEnvironment webHostEnvironment, IAuthor author)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _author = author;
        }

        [HttpGet]
        [Route("Author/Index")]
        public IActionResult Index()
        {
            try
            {
                var response = _author.Index();
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Author/Details")]
        public IActionResult Details(string emailId)
        {
            try
            {
                var response = _author.Details(emailId);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("Author/Create")]
        public async Task<IActionResult> CreateAsync([Bind("Title,Category,Price,Publisher,Active,BookContent,Author,EmailId")] Book book)
        {
            try
            {
                var response = await _author.CreateAsync(book);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Author/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Books == null)
            {
                return NotFound();
            }

            var response = await _db.Books.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Author/Edit")]
        public async Task<IActionResult> EditAsync([Bind("Title,Category,Price,Publisher,Active,BookContent,Author,EmailId")] Book book, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = await _author.EditAsync(book, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Author/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _db.Books == null)
            {
                return NotFound();
            }

            var book = await _db.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpDelete]
        [Route("Author/Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _author.DeleteAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Author/BlockBook")]
        public async Task<IActionResult> BlockBook(int? id)
        {
            if (id == null || _db.Books == null)
            {
                return NotFound();
            }

            var response = await _db.Books.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Author/BlockBook")]
        public async Task<IActionResult> BlockBookAsync(int id)
        {
            try
            {
                var response = await _author.BlockBookAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Author/UnblockBook")]
        public async Task<IActionResult> UnblockBook(int? id)
        {
            if (id == null || _db.Books == null)
            {
                return NotFound();
            }

            var response = await _db.Books.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Author/UnblockBook")]
        public async Task<IActionResult> UnblockBookAsync(int id)
        {
            try
            {
                var response = await _author.UnblockBookAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}



