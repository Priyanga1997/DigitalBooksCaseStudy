using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReaderAPI.Models;
using ReaderAPI.Services;

namespace ReaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly DigitalBooksContext _db;
        IReader _reader;
        public ReaderController(DigitalBooksContext db, IReader reader)
        {
            _db = db;
            _reader = reader;
        }

        [HttpGet]
        [Route("Reader/Index")]
        public IActionResult SearchBooks(string title, string category, int price, string publisher, string author)
        {
            try
            {
                var response = _reader.SearchBooks(title, category, price, publisher, author);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Reader/Subscribe")]
        public async Task<IActionResult> Subscribe(int? id)
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
        [HttpPost]
        [Route("Reader/Subscribe")]
        public async Task<IActionResult> SubscribeAsync(Subscription subscription)
        {
            try
            {
                var response = _reader.SubscribeAsync(subscription);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Reader/GetAllSubscriptionDetails")]
        public IActionResult GetAllSubscriptionDetails(string emailId)
        {
            try
            {
                var response = _reader.GetAllSubscriptionDetails(emailId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Reader/GetSubscriptionDetailsBySubscriptionId")]
        public IActionResult GetSubscriptionDetailsBySubscriptionId(int subscriptionId, string emailId)
        {
            try
            {
                var response = _reader.GetSubscriptionDetailsBySubscriptionId(subscriptionId, emailId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Reader/ReadBook")]
        public async Task<IActionResult> ReadBookAsync(int subscriptionId, string emailId)
        {
            try
            {
                var response = await _reader.ReadBookAsync(subscriptionId, emailId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("Reader/Admin")]
        public async Task<IActionResult> AdminAsync()
        {
            try
            {
                var response = await _reader.AdminViewAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }


        [HttpPut]
        [Route("Reader/CancelSubscription")]
        public async Task<IActionResult> CancelSubscriptionAsync(int subscriptionId)
        {
            try
            {
                var response = await _reader.CancelSubscriptionAsync(subscriptionId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
