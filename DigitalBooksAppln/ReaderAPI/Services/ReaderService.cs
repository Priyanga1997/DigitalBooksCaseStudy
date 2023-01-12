using Microsoft.AspNetCore.SignalR;
using ReaderAPI.Models;

namespace ReaderAPI.Services
{
    public class ReaderService :IReader
    {
        DigitalBooksContext _db;
        public ReaderService(DigitalBooksContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> SearchBooks(string title, string category, int price, string publisher, string author)
        {
            var data = (from b in _db.Books where (b.Active == "yes" && (b.Title == title || b.Category == category || b.Price == price || b.Publisher == publisher || b.Author == author)) select b).ToList();
            return data;
        }

        public async Task<Subscription> SubscribeAsync(Subscription subscription)
        {      
                _db.Subscriptions.Add(subscription);
                _db.SaveChanges();
                return subscription;
        }

        public IEnumerable<Subscription> GetAllSubscriptionDetails(string emailId)
        {
            var data = (from a in _db.Subscriptions
                        where (a.EmailId == emailId)
                        orderby a.SubscriptionId descending
                        select a).ToList();
            return data;
        }

        public IEnumerable<Subscription> GetSubscriptionDetailsBySubscriptionId(int subscriptionId, string emailId)
        {

            var data = (from a in _db.Subscriptions
                        where ((a.SubscriptionId == subscriptionId) && (a.EmailId == emailId))
                        select a).ToList();
            return data;
        }

        public async Task<dynamic> ReadBookAsync(int subscriptionId, string emailId)
        {
            try
            {
                var data = (from a in _db.Subscriptions
                            join b in _db.Books on a.BookId equals b.BookId
                            where ((a.SubscriptionId == subscriptionId) && (a.EmailId == emailId))
                            select b.BookContent).ToList();
                return data;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<dynamic> AdminViewAsync()
        {
            try
            {
                var data = (from a in _db.Subscriptions
                            join b in _db.Books on a.BookId equals b.BookId
                            join c in _db.Users on a.UserId equals c.UserId select new { a.SubscriptionId, b.Title, b.Author }).ToList();
                return data;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<dynamic> CancelSubscriptionAsync(int subscriptionId)
        {
            try
            {
                var cancelSubsciption = _db.Subscriptions.Where(x => x.SubscriptionId == subscriptionId).FirstOrDefault();
                cancelSubsciption.SubscriptionActive = "no";
                _db.Subscriptions.Update(cancelSubsciption);
                _db.SaveChanges();
                return "Book subscription got cancelled successfully";
            }
            catch (Exception ex)
            {
                return ex;
            }

        }
    }
}
