//using BookMicroservice;
//using BookMicroservice.Models;
//using BookMicroservice.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace DigitalBooksApplication.Controllers
//{
//    public class ReaderController : Controller
//    {
//        private readonly DigitalBooksContext _db;
//        IReader _reader;
//        public ReaderController(DigitalBooksContext db, IReader reader)
//        {
//            _db = db;
//            _reader = reader;
//        }

//        [HttpGet]
//        [Route("Reader/Index")]
//        public IActionResult SearchBooks(string title, string category, int price, string publisher, string author)
//        {
//            try
//            {
//                var response = _reader.SearchBooks(title, category, price, publisher, author);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpPost]
//        [Route("Reader/Subscribe")]
//        public async Task<IActionResult> SubscribeAsync(Subscription subscription)
//        {
//            try
//            {
//                var response = _reader.SubscribeAsync(subscription);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpGet]
//        [Route("Reader/GetAllSubscriptionDetails")]
//        public IActionResult GetAllSubscriptionDetails(string emailId)
//        {
//            try
//            {
//                var response = _reader.GetAllSubscriptionDetails(emailId);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpGet]
//        [Route("Reader/GetSubscriptionDetailsBySubscriptionId")]
//        public IActionResult GetSubscriptionDetailsBySubscriptionId(int subscriptionId, string emailId)
//        {
//            try
//            {
//                var response = _reader.GetSubscriptionDetailsBySubscriptionId(subscriptionId, emailId);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpGet]
//        [Route("Reader/ReadBook")]
//        public async Task<IActionResult> ReadBookAsync(int subscriptionId, string emailId)
//        {
//            try
//            {
//                var response = await _reader.ReadBookAsync(subscriptionId, emailId);
//                return Ok(response);
//            }
//            catch (CustomException ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }

//        [HttpGet]
//        [Route("Reader/Admin")]
//        public async Task<IActionResult> AdminAsync()
//        {
//            try
//            {
//                var response = await _reader.AdminViewAsync();
//                return Ok(response);
//            }
//            catch (CustomException ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }


//        [HttpPut]
//        [Route("Reader/CancelSubscription")]
//        public async Task<IActionResult> CancelSubscriptionAsync(int subscriptionId)
//        {
//            try
//            {
//                var response = await _reader.CancelSubscriptionAsync(subscriptionId);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"{ex.Message}");
//            }
//        }
//    }
//}


