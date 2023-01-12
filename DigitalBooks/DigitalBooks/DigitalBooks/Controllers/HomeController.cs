using DigitalBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DigitalBooksContext _db;
        public HomeController(ILogger<HomeController> logger, DigitalBooksContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(string SearchText="")
        {
            List<Book> books;
            if (SearchText != "" && SearchText != null)
            {
                books = _db.Books.Where(p => p.Title.Contains(SearchText) || p.Author.Contains(SearchText) || p.Category.Contains(SearchText)).ToList();
            }
            else
            {
                books = _db.Books.ToList();
            }
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
