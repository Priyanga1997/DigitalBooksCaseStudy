//using AuthorAPI.Services;
//using Azure;
//using Azure.Storage.Blobs;
//using DigitalBooksApplication.Models;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using NuGet.Protocol.Core.Types;
//using System.Collections.Generic;
//using System.Net.Http.Headers;
//using System.Text;

//namespace DigitalBooksApplication.Controllers
//{
//    public class AuthorController : Controller
//    {
//        private readonly DigitalBooksContext _db;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        IAuthor _author;
//        public AuthorController(DigitalBooksContext db, IWebHostEnvironment webHostEnvironment, IAuthor author)
//        {
//            _db = db;
//            _webHostEnvironment = webHostEnvironment;
//            _author = author;
//        }

//        [HttpGet]
//        [Route("Author/Index")]
//        public IActionResult Index()
//        {
//            try
//            {
//                var response = _author.Index();
//                return View(response);
//            }
//            catch (CustomException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet]
//        [Route("Author/Details/emailId")]
//        public IActionResult Details(string emailId)
//        {
//            try
//            {
//                var response = _author.Details(emailId);
//                if (response == null)
//                {
//                    return NotFound();
//                }
//                return View(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpGet]
//        [Route("Author/Create")]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [Route("Author/Create")]
//        public async Task<IActionResult> CreateAsync([Bind("Title,Category,Image,Price,Publisher,Active,BookContent,Author,EmailId")] BookModel bookModel)
//        {
//            string dbPath = string.Empty;
//            try
//            {
//                var file = Request.Form.Files[0];
//                if (file.Length > 0)
//                {
//                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
//                    var _filename = Path.GetFileNameWithoutExtension(fileName);
//                    fileName = _filename + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
//                    dbPath = fileName;
//                    string connectionstring = "DefaultEndpointsProtocol=https;AccountName=digitalbooksa;AccountKey=bhp2zcXA97ZXH/caVC6cFIVnAUIZ8eJbN1eZEZIMTkxIYtv6FW4uyEbtuOHhwnl5C0o/Mjk+3l/I+AStSsHLwQ==;EndpointSuffix=core.windows.net";
//                    string containerName = "testcontainer";
//                    BlobContainerClient container = new BlobContainerClient(connectionstring, containerName);
//                    var blob = container.GetBlobClient(fileName);
//                    var blobstream = file.OpenReadStream();
//                    await blob.UploadAsync(blobstream);
//                    var URI = blob.Uri.AbsoluteUri;

//                    if (!ModelState.IsValid)
//                    {
//                        return BadRequest();
//                    }
//                }
//                var response = await _author.CreateAsync(bookModel, dbPath);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpGet]
//        [Route("Author/Edit")]
//        public async Task<IActionResult> Edit(int id)
//        {
//            if (id == null || _db.Books == null)
//            {
//                return NotFound();
//            }

//            var book = await _db.Books.FindAsync(id);
//            if (book == null)
//            {
//                return NotFound();
//            }
//            return View(book);
//        }

//        [HttpPost]
//        [Route("Author/Edit")]
//        public async Task<IActionResult> EditAsync([Bind("Title,Category,Price,Publisher,Active,BookContent,Author,EmailId")] BookModel bookmodel, int id)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest();
//                }
//                var response = await _author.EditAsync(bookmodel, id);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpGet]
//        [Route("Author/Delete")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            if (id == null || _db.Books == null)
//            {
//                return NotFound();
//            }

//            var book = await _db.Books
//                .FirstOrDefaultAsync(m => m.BookId == id);
//            if (book == null)
//            {
//                return NotFound();
//            }

//            return View(book);
//        }

//        [HttpPost]
//        [Route("Author/Delete")]
//        public async Task<IActionResult> DeleteAsync(int id)
//        {
//            try
//            {
//                var response = await _author.DeleteAsync(id);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpPut]
//        [Route("Author/BlockBook")]
//        public async Task<IActionResult> BlockBookAsync(int id)
//        {
//            try
//            {
//                var response = await _author.BlockBookAsync(id);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpPut]
//        [Route("Author/UnblockBook")]
//        public async Task<IActionResult> UnblockBookAsync(int id)
//        {
//            try
//            {
//                var response = await _author.UnblockBookAsync(id);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }
//    }
//}


