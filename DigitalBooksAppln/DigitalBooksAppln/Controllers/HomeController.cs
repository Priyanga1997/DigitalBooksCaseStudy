using DigitalBooksAppln.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace DigitalBooksAppln.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Method to get and display all book details
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="searchValue"></param>
        /// <param name="pageNumber"></param>
        /// <param name="currentFilter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchValue, int? pageNumber, string currentFilter)
        {
            ViewData["TitleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["CategorySortParam"] = string.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewData["PriceSortParam"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["PublisherSortParam"] = string.IsNullOrEmpty(sortOrder) ? "publisher_desc" : "";
            ViewData["BookContentSortParam"] = string.IsNullOrEmpty(sortOrder) ? "bookContent_desc" : "";
            ViewData["AuthorSortParam"] = string.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
            ViewData["ActiveSortParam"] = string.IsNullOrEmpty(sortOrder) ? "active_desc" : "";
            ViewData["BookIdSortParam"] = string.IsNullOrEmpty(sortOrder) ? "bookId_desc" : "";
            ViewData["CurrentFilter"] = searchValue;
            if (searchValue != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchValue = currentFilter;
            }
            string BaseUrl = "https://localhost:7042/";
            using (var client = new HttpClient())
            {
                List<Book> books = new List<Book>();
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Author/Author/Index");
                if (response.IsSuccessStatusCode)
                {
                    var bookResult = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Book>>(bookResult);
                    var bookResponse = from book in books
                                       select (new Book() { Title = book.Title, Category = book.Category, Price = book.Price, Publisher = book.Publisher, BookContent = book.BookContent, Author = book.Author, Active = book.Active, BookId = book.BookId });
                    //Searching
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        bookResponse = bookResponse.Where(s => s.Title.ToLower().Contains(searchValue.ToLower())
                                               || s.Category.ToLower().Contains(searchValue.ToLower())
                                               || s.Price.ToString().Contains(searchValue)
                                               || s.Publisher.ToLower().Contains(searchValue.ToLower())
                                               || s.BookContent.ToLower().Contains(searchValue.ToLower())
                                               || s.Author.ToLower().Contains(searchValue.ToLower())
                                               || s.Active.ToLower().Contains(searchValue.ToLower())
                                               || s.BookId.ToString().Contains(searchValue));
                    }
                    //sorting
                    switch (sortOrder)
                    {
                        case "title_desc":
                            bookResponse = bookResponse.OrderByDescending(x => x.Title);
                            break;

                        case "category_desc":
                            bookResponse = bookResponse.OrderByDescending(x => x.Category);
                            break;

                        case "price_desc":
                            bookResponse = bookResponse.OrderBy(x => x.Price);
                            break;

                        case "publisher_desc":
                            bookResponse = bookResponse.OrderByDescending(x => x.Publisher);
                            break;

                        case "bookContent_desc":
                            bookResponse = bookResponse.OrderByDescending(x => x.BookContent);
                            break;

                        case "author_desc":
                            bookResponse = bookResponse.OrderByDescending(x => x.Author);
                            break;

                        case "active_desc":
                            bookResponse = bookResponse.OrderByDescending(x => x.Active);
                            break;

                        case "bookId_desc":
                            bookResponse = bookResponse.OrderByDescending(x => x.BookId);
                            break;

                    }
                    return View(bookResponse);
                }
                else
                {
                    return View();
                }
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