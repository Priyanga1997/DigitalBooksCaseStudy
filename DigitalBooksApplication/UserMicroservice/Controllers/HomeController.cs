using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserMicroservice.Models;

namespace UserMicroservice.Controllers
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

        [HttpGet]
        public IActionResult Index(string searchValue)
        {
            List<Book> response = null;
            try
            {
                response = _db.Books.ToList();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    response = response.Where(s => s.Title!.Contains(searchValue)|| s.Category!.Contains(searchValue)).ToList();
                }
                return View(response);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Internal error. Please contact admin";
                return BadRequest(ex.Message);
            }
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