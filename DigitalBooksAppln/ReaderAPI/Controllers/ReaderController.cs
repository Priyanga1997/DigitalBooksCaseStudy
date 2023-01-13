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

        /// <summary>
        /// Api method to search books
        /// </summary>
        /// <param name="title"></param>
        /// <param name="category"></param>
        /// <param name="price"></param>
        /// <param name="publisher"></param>
        /// <param name="author"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Api method to get the book id to be subscribed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Reader/Subscribe")]
        public async Task<IActionResult> SubscribeAsync(int? id)
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

        /// <summary>
        /// Api method to subcribe books
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Api method to get all the subscription details by emailID
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Api method to get the subscription details by subscription id
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Api method to read books
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Api method to cancel subscription
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
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
