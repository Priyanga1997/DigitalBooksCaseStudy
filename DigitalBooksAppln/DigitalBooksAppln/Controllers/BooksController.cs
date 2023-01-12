﻿using Azure;
using DigitalBooksAppln.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Azure;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Web.Http.Results;
using static System.Net.WebRequestMethods;

namespace DigitalBooksAppln.Controllers
{
    public class BooksController : Controller
    {
        private IHttpContextAccessor _httpContext;
        public BooksController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        [Route("Books/Details")]
        public async Task<IActionResult> Details(string emailId, string? token, string username)
        {
            string Baseurl = "https://localhost:7042/";
            string response = string.Empty;
            List<Book> books = new List<Book>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                token = _httpContext.HttpContext.Session.GetString("token");
                emailId = _httpContext.HttpContext.Session.GetString("emailId");
                username= _httpContext.HttpContext.Session.GetString("username");
                HttpResponseMessage res = await client.GetAsync("api/Author/Author/Details?emailId="+emailId);
                if (res.IsSuccessStatusCode)
                {
                     response = await res.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Book>>(response);
                    var bookResponse = from book in books
                                       select (new Book() { Title = book.Title, Category = book.Category, Price = book.Price, Publisher = book.Publisher, BookContent = book.BookContent, Author = book.Author , Active= book.Active, BookId = book.BookId});
                    return View(bookResponse);
                }
                else
                {
                    return View();
                }
            }
            
        }

        [Route("Books/Create")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Books/Create")]
        public async Task<IActionResult> Create(Book bookModel, string? token, string? emailId)
        {
            string Baseurl = "https://localhost:7042/api/Author/Author/Create";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                int userId = int.Parse(_httpContext.HttpContext.Session.GetString("userId"));
                Book book = new Book();
                book.BookId = bookModel.BookId;
                book.Title = bookModel.Title;
                book.Category = bookModel.Category;
                book.Author = bookModel.Author;
                book.Publisher = bookModel.Publisher;
                book.Price = bookModel.Price;
                book.Active = bookModel.Active;
                book.BookContent = bookModel.BookContent;
                book.UserId = userId;
                book.EmailId = bookModel.EmailId;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(Baseurl, content);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                   
                }
            }
            //TempData["SuccessMessage"] = "Book has been created Successfully";
            return RedirectToAction("Create", "Books");
        }

        [Route("Books/Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            {
                string Baseurl = "https://localhost:7042/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    HttpResponseMessage res = await client.GetAsync("api/Author/Author/Edit?id=" + id);
                    if (res.IsSuccessStatusCode)
                    {
                        var  response =  res.Content.ReadAsStringAsync();
                        var books = JsonConvert.DeserializeObject<Book>(response.Result);
                        var bookResponse = books;
                        return View(bookResponse);
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }

        [HttpPost]
        [Route("Books/Edit")]
        public async Task<IActionResult> Edit(Book bookModel, int bookId)
        {
            string Baseurl = "https://localhost:7042/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var content = new StringContent(JsonConvert.SerializeObject(bookModel), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync("api/Author/Author/Edit?id=" + bookId, content);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            TempData["SuccessMessage"] = "Book has been updated Successfully";
            return RedirectToAction("Details", "Books", response);
        }

        [Route("Books/Delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            {
                string Baseurl = "https://localhost:7042/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    HttpResponseMessage res = await client.GetAsync("api/Author/Author/Delete?id=" + id);
                    if (res.IsSuccessStatusCode)
                    {
                        var response = res.Content.ReadAsStringAsync();
                        var books = JsonConvert.DeserializeObject<Book>(response.Result);
                        var bookResponse = books;                      
                        return View(bookResponse);
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }

        [HttpPost]
        [Route("Books/Delete")]
        public async Task<IActionResult> Delete1(int bookId)
        {
            string Baseurl = "https://localhost:7042/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var content = new StringContent(JsonConvert.SerializeObject(bookId), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.DeleteAsync("api/Author/Author/Delete?id=" + bookId);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            TempData["SuccessMessage"] = "Book has been deleted Successfully";
            return RedirectToAction("Details", "Books", response);
        }

        [Route("Books/BlockBook")]
        public async Task<dynamic> BlockBook(int id)
        {
            string Baseurl = "https://localhost:7042/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync("api/Author/Author/BlockBook?id=" + id, content);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            return "Book has been blocked successfully";
        }

        [Route("Books/UnblockBook")]
        public async Task<dynamic> UnblockBook(int id)
        {
            string Baseurl = "https://localhost:7042/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //string param = $"id={bookId}";
                var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync("api/Author/Author/UnblockBook?id=" + id, content);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            return "Book has been unblocked successfully";
        }

        //[Route("Books/Search")]
        //[HttpGet]
        //public async Task<IActionResult> Search(List<Book> book)
        //{
        //    string Baseurl = "https://localhost:7042/";
        //    string response = string.Empty;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        HttpResponseMessage res = await client.GetAsync("api/Author/Author/Index");
        //        if (res.IsSuccessStatusCode)
        //        {
        //            response = res.Content.ReadAsStringAsync().Result;
        //        }
        //    }
        //    return View(response);
        //}

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        [Route("Books/Search")]

        public async Task<IActionResult> Search(string sortOrder, string title,string category, string price, string publisher, string author)
        {
            ViewData["TitleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["CategorySortParam"] = string.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewData["PriceSortParam"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["PublisherSortParam"] = string.IsNullOrEmpty(sortOrder) ? "publisher_desc" : "";
            ViewData["AuthorSortParam"] = string.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
            string BaseUrl = "https://localhost:7042/";
            using (var client = new HttpClient())
            {
                List<Book> books = new List<Book>();
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Author/Author/Index");
                if (response.IsSuccessStatusCode)
                {
                    var bookResult = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Book>>(bookResult);
                    var bookResponse = from book in books
                                       select (new Book() { Title = book.Title, Category = book.Category, Price = book.Price, Publisher = book.Publisher, BookContent = book.BookContent, Author = book.Author, Active = book.Active, BookId = book.BookId });
                    //Searching
                    if (!string.IsNullOrEmpty(title)||!string.IsNullOrEmpty(category))
                    {
                        bookResponse = bookResponse.Where(s => s.Title.ToLower().Contains(title.ToLower())
                                               || s.Category.ToLower().Contains(category.ToLower())
                                               || s.Price.ToString().Contains(price)
                                               || s.Publisher.ToLower().Contains(publisher.ToLower())
                                               //|| s.BookContent.ToLower().Contains(book.ToLower())
                                               || s.Author.ToLower().Contains(author.ToLower()));
                                               //|| s.Active.ToLower().Contains(search.ToLower())
                                              // || s.BookId.ToString().Contains(search));
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
        
        [Route("Books/SearchBooks")]
        public async Task<IActionResult> SearchBooks(string title, string category, int price, string publisher, string author)
        {
            string Baseurl = "https://localhost:7011/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                string param = $"title={title}&category={category}&price={price}&publisher={publisher}&author={author}";
                HttpResponseMessage res = await client.GetAsync("api/Reader/Reader/Index?" + param);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            return RedirectToAction("Search", "Books", response);
        }

        //[Route("Books/Subscribe")]
        //[HttpGet]
        //public async Task<IActionResult> Subscribe(int bookId)
        //{
        //    {
        //        string Baseurl = "https://localhost:7011/";
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();
        //            HttpResponseMessage res = await client.GetAsync("api/Reader/Reader/Subscribe?id=" + bookId);
        //            if (res.IsSuccessStatusCode)
        //            {
        //                var response = res.Content.ReadAsStringAsync();
        //                var books = JsonConvert.DeserializeObject<List<Subscription>>(response.Result);
        //                var bookResponse = books;
        //                return View(bookResponse);
        //            }
        //            else
        //            {
        //                return View();
        //            }
        //        }
        //    }
        //}

        [Route("Books/SubscribeBooks")]
        public async Task<IActionResult> SubscribeBooks(Book book)
        {
            string Baseurl = "https://localhost:7011/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                Subscription subscription = new Subscription();
                subscription.BookId = book.BookId;
                subscription.Title = book.Title;
                subscription.Author = book.Author;
                subscription.EmailId = _httpContext.HttpContext.Session.GetString("emailId");
                subscription.SubscriptionActive = "yes";
                subscription.UserId = int.Parse(_httpContext.HttpContext.Session.GetString("userId"));
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var content = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/Reader/Reader/Subscribe", content);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                    var subscribeBooks = JsonConvert.DeserializeObject<Subscription>(response);
                }
            }
          return RedirectToAction("Subscribe", "Books", response);
        }

        [Route("Books/Subscribe")]
        [HttpGet]
        public async Task<IActionResult> Subscribe(string emailId)
        {
            string response = string.Empty;
            List<Subscription> subscriptions = new List<Subscription>();
            string Baseurl = "https://localhost:7011/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    emailId = _httpContext.HttpContext.Session.GetString("emailId");
                HttpResponseMessage res = await client.GetAsync("api/Reader/Reader/GetAllSubscriptionDetails?emailId="+emailId);
                    if (res.IsSuccessStatusCode)
                    {
                        response = await res.Content.ReadAsStringAsync();
                        subscriptions = JsonConvert.DeserializeObject<List<Subscription>>(response);
                        var subscriptionResponse = from subscription in subscriptions
                                           select (new Subscription() { Title = subscription.Title,Author = subscription.Author, SubscriptionActive = subscription.SubscriptionActive, BookId = subscription.BookId ,SubscriptionId=subscription.SubscriptionId});
                        return View(subscriptionResponse);
                    }
                    else
                    {
                        return View();
                    }
                }
            }

        [Route("Books/CancelSubscription")]
        public async Task<IActionResult> CancelSubscription(int subscriptionId)
        {
            string response = string.Empty;
            List<Subscription> subscriptions = new List<Subscription>();
            string Baseurl = "https://localhost:7011/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var content = new StringContent(JsonConvert.SerializeObject(subscriptionId), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync("api/Reader/Reader/CancelSubscription?subscriptionId=" + subscriptionId,content );
                    if (res.IsSuccessStatusCode)
                    {
                        response = res.Content.ReadAsStringAsync().Result;
                    }
                TempData["SuccessMessage"] = "Book has been unsubscribed Successfully";
                return RedirectToAction("Subscribe", "Books", response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReadBook(int subscriptionId,string emailId)
        {
            string response = string.Empty;
            List<Subscription> subscriptions = new List<Subscription>();
            var books = new Book();
            string Baseurl = "https://localhost:7011/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                emailId = _httpContext.HttpContext.Session.GetString("emailId");
                string param = $"emailId={emailId}&subscriptionId={subscriptionId}";
                HttpResponseMessage res = await client.GetAsync("api/Reader/Reader/ReadBook?"+param);
                if (res.IsSuccessStatusCode)
                {
                    response = await res.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<Book>(response);
                }
            }
            return RedirectToAction("Subscribe", "Books", books);
        }

        [HttpGet]
        [Route("Books/AdminView")]
        public async Task<IActionResult> AdminView()
        {
            string Baseurl = "http://localhost:7224/api/Function1";
            string url = "https://azurefunctions20230111173852.azurewebsites.net/api/Function1?code=mqdMXRmrnS5WO09ySfV1RHzAIQazGcLYBQZoj-_en0HJAzFu5yVV_A==";
            string response = string.Empty;
            List<Subscription> subscriptions = new List<Subscription>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage res = await client.GetAsync(Baseurl);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                    subscriptions = JsonConvert.DeserializeObject<List<Subscription>>(response);
                }
            }
            return View(subscriptions);
        }
    }
}
