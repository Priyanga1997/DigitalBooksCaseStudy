//using SharedModel;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;

//namespace AuthorAPI.Services
//{
//    public class AuthorImpl : IAuthor
//    {
//        DigitalBooksContext _db;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        public AuthorImpl(DigitalBooksContext db, IWebHostEnvironment webHostEnvironment)
//        {
//            _db = db;
//            _webHostEnvironment = webHostEnvironment;
//        }

//        public IEnumerable<Book> Index()
//        {
//            var books = _db.Books.ToList();
//            return books;
//        }

//        public IEnumerable<Book> Details(string emailId)
//        {
//            List<Book> books = _db.Books
//                 .Where(x => x.EmailId == emailId)
//                 .ToList();
//            return books;
//        }

//        public async Task<Book> CreateAsync([Bind(new[] { "Title,Category,Image,Price,Publisher,Active,BookContent,Author,EmailId" })] BookModel bookModel, string dbPath)
//        {
//            Book obj = new Book();
//            obj.Title = bookModel.Title;
//            obj.Price = Convert.ToInt32(bookModel.Price);
//            obj.Category = bookModel.Category;
//            obj.Publisher = bookModel.Publisher;
//            obj.Active = bookModel.Active;
//            obj.BookContent = bookModel.BookContent;
//            obj.Image = dbPath;
//            obj.Author = bookModel.Author;
//            obj.EmailId = bookModel.EmailId;
//            _db.Books.Add(obj);
//            _db.SaveChanges();
//            return obj;
//        }

//        public async Task<Book> EditAsync([Bind(new[] { "Title,Category,Image,Price,Publisher,Active,BookContent,Author,EmailId" })] BookModel bookmodel, int id)
//        {
//            var book = _db.Books.Where(x => x.BookId == id).FirstOrDefault();
//            if (book != null)
//            {
//                //if (bookmodel.Image != null)
//                //{
//                string folder = "books/Images";
//                folder += bookmodel.Image.FileName + DateTime.Now.ToString("yyyyMMddHHmmss");
//                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
//                bookmodel.Image.CopyTo(new FileStream(serverFolder, FileMode.Create));
//                book.Title = bookmodel.Title;
//                book.Category = bookmodel.Category;
//                book.Price = bookmodel.Price;
//                book.Publisher = bookmodel.Publisher;
//                book.Active = bookmodel.Active;
//                book.BookContent = bookmodel.BookContent;
//                book.Author = bookmodel.Author;
//                book.EmailId = bookmodel.EmailId;
//                book.Image = folder;
//                _db.Books.Update(book);
//                _db.SaveChanges();
//                // }
//            }
//            return book;
//        }

//        public async Task<Book> DeleteAsync(int id)
//        {
//            var data = _db.Books.Where(x => x.BookId == id).FirstOrDefault();
//            if (data != null)
//            {
//                _db.Books.Remove(data);
//                _db.SaveChanges();
//            }
//            return data;
//        }

//        public async Task<Book> BlockBookAsync(int id)
//        {
//            var blockBook = _db.Books.Where(s => s.BookId == id).FirstOrDefault();
//            blockBook.Active = "no";
//            _db.Books.Update(blockBook);
//            _db.SaveChanges();
//            return blockBook;
//        }

//        public async Task<Book> UnblockBookAsync(int id)
//        {
//            var UnblockBook = _db.Books.Where(s => s.BookId == id).FirstOrDefault();
//            UnblockBook.Active = "yes";
//            _db.Books.Update(UnblockBook);
//            _db.SaveChanges();
//            return UnblockBook;
//        }
//    }
//}



