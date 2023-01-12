using DigitalBooks.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace DigitalBooks.Controllers
{
    public class AuthorController : Controller
    {
        private readonly DigitalBooksContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthorController(DigitalBooksContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("Author/Index")]
        public IActionResult Index()
        {
            var books = _db.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookModel book = new BookModel();
            return View(book);
        }

        [HttpGet]
        //[Route("Author/Details/{emailId?}")]
        //[Route("getBooksByEmailId")]
        public ActionResult Details(string emailId)
        {
            if (emailId == null)
            {
                return BadRequest();
            }
            var books = _db.Books.Find(emailId);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        [HttpPost]
        public IActionResult Create(BookModel bookmodel)
        {
            Book book = new Book();
            if (ModelState.IsValid)
            {
                if (bookmodel.Image != null)
                {
                    string folder = "books/Images";
                    folder += bookmodel.Image.FileName + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    bookmodel.Image.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    book.Title = bookmodel.Title;
                    book.Category = bookmodel.Category;
                    book.Price = bookmodel.Price;
                    book.Publisher = bookmodel.Publisher;
                    book.Active = bookmodel.Active;
                    book.BookContent = bookmodel.BookContent;
                    book.Author = bookmodel.Author;
                    book.EmailId = bookmodel.EmailId;
                    book.Image = folder;
                    _db.Books.Add(book);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }             
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            Book book = new Book();
            return View(book);
        }

        [HttpPut]
        //[Route("Author/Edit/{id?}")]
        public ActionResult Edit(BookModel bookmodel, int id)
        {
            var data = _db.Books.Where(x => x.Id == id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }
            Book book = new Book();
            if (ModelState.IsValid)
            {
                if (bookmodel.Image != null)
                {
                    string folder = "books/Images";
                    folder += bookmodel.Image.FileName + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    bookmodel.Image.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    book.Title = bookmodel.Title;
                    book.Category = bookmodel.Category;
                    book.Price = bookmodel.Price;
                    book.Publisher = bookmodel.Publisher;
                    book.Active = bookmodel.Active;
                    book.BookContent = bookmodel.BookContent;
                    book.Author = bookmodel.Author;
                    book.EmailId = bookmodel.EmailId;
                    book.Image = folder;
                    _db.Books.Update(data);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            Book book = new Book();
            return View(book);
        }

        [HttpDelete]
        //[Route("Author/Delete/{id?}")]
        public IActionResult Delete(int id)
        {
            var data = _db.Books.Where(x => x.Id == id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }
            _db.Books.Remove(data);
            _db.SaveChanges();
            return View(data);
        }
    }
}
