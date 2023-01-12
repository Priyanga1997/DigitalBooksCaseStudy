using BookMicroservice.Models;

namespace BookMicroservice.Services
{
    public class ReaderImpl : IReader
    {
        DigitalBooksContext _db;
        public ReaderImpl(DigitalBooksContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> SearchBooks(string title, string category, int price, string publisher, string author)
        {
            var data = (from b in _db.Books where (b.Active == "yes" && (b.Title == title || b.Category == category || b.Price == price || b.Publisher == publisher || b.Author == author)) select b).ToList();
            return data;
        }

        public async Task<dynamic> SubscribeAsync(Subscription subscription)
        {
            try
            {
                if (subscription != null)
                {
                    _db.Subscriptions.Add(subscription);
                    _db.SaveChanges();
                }
                return "Book has been subscribed successfully";
            }
            catch (Exception ex)
            {
                return ex;
            }
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
                var data = (from a in _db.Users
                            join b in _db.Subscriptions on a.UserId equals b.UserId
                            where ((a.UserType == "Reader"))
                            select new {b.Title , b.Author}).ToList();
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
