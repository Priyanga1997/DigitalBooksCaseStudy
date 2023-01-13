using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Services
{
    public class AuthorService : IAuthor
    {
        DigitalBooksContext _db;
        public AuthorService(DigitalBooksContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Index()
        {
            var books = _db.Books.ToList();
            return books;
        }

        public IEnumerable<Book> Details(string emailId)
        {
            List<Book> books = _db.Books
                 .Where(x => x.EmailId == emailId)
                 .ToList();
            return books;
        }

        public async Task<Book> CreateAsync([Bind(new[] { "Title,Category,Price,Publisher,Active,BookContent,Author,EmailId" })] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return book;
        }

        public async Task<Book> EditAsync([Bind(new[] { "Title,Category,Image,Price,Publisher,Active,BookContent,Author,EmailId" })] Book bookmodel, int id)
        {
            var book = _db.Books.Where(x => x.BookId == id).FirstOrDefault();
            if (book != null)
            {
                book.Title = bookmodel.Title;
                book.Category = bookmodel.Category;
                book.Price = bookmodel.Price;
                book.Publisher = bookmodel.Publisher;
                book.Active = bookmodel.Active;
                book.BookContent = bookmodel.BookContent;
                book.Author = bookmodel.Author;
                book.EmailId = bookmodel.EmailId;
                _db.Books.Update(book);
                _db.SaveChanges();
            }
            return book;
        }

        public async Task<Book> DeleteAsync(int id)
        {
            var data = _db.Books.Where(x => x.BookId == id).FirstOrDefault();
            if (data != null)
            {
                _db.Books.Remove(data);
                _db.SaveChanges();
            }
            return data;
        }

        public async Task<Book> BlockBookAsync(int id)
        {
            var blockBook = _db.Books.Where(s => s.BookId == id).FirstOrDefault();
            blockBook.Active = "no";
            _db.Books.Update(blockBook);
            _db.SaveChanges();
            return blockBook;
        }

        public async Task<Book> UnblockBookAsync(int id)
        {
            var UnblockBook = _db.Books.Where(s => s.BookId == id).FirstOrDefault();
            UnblockBook.Active = "yes";
            _db.Books.Update(UnblockBook);
            _db.SaveChanges();
            return UnblockBook;
        }
    }
}



