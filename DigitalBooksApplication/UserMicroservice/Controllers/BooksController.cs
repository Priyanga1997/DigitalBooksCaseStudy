using BookMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace UserMicroservice.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Books/CallGetAPI")]
        [HttpGet]
        public async Task<IActionResult> CallGetAPI()
        {
            string Baseurl = "https://localhost:7029/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage res = await client.GetAsync("Author/Index");
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            return Ok(response);
        }

        [Route("Books/CallPostAPI")]
        [HttpGet]
        public async Task<IActionResult> CallPostAPI()
        {
            string Baseurl = "https://localhost:7029/";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage res = await client.GetAsync("Author/Create");
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            //return Ok(response);
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = response
            };
        }

        [Route("Books/CallEditAPI")]
        [HttpGet]
        public async Task<IActionResult> CallEditAPI()
        {
            string Baseurl = "https://localhost:7029/";
            string response = string.Empty;
            List<Book> postData = new List<Book>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync("Author/Edit", content);
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            return Ok(response);
        }

        [Route("Books/CallDeleteAPI")]
        [HttpGet]
        public async Task<IActionResult> CallDeleteAPI()
        {
            string Baseurl = "https://localhost:7029/";
            string response = string.Empty;
            List<Book> postData = new List<Book>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.DeleteAsync("Author/Delete");
                if (res.IsSuccessStatusCode)
                {
                    response = res.Content.ReadAsStringAsync().Result;
                }
            }
            return Ok(response);
        }
    }
}
