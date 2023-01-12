using ReaderAPI.Models;

namespace ReaderAPI.Services
{
    public interface IReader
    {
        IEnumerable<Book> SearchBooks(string title, string category, int price, string publisher, string author);
        Task<Subscription> SubscribeAsync(Subscription subscription);
        IEnumerable<Subscription> GetAllSubscriptionDetails(string emailId);
        IEnumerable<Subscription> GetSubscriptionDetailsBySubscriptionId(int subscriptionId, string emailId);
        Task<dynamic> CancelSubscriptionAsync(int subscriptionId);
        Task<dynamic> ReadBookAsync(int subscriptionId, string emailId);
        Task<dynamic> AdminViewAsync();
    }
}
