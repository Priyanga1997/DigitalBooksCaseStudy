using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Services
{
    public interface IAuthor
    {
        IEnumerable<Book> Index();
        IEnumerable<Book> Details(string emailId);
        Task<Book> CreateAsync([Bind("Title,Category,Price,Publisher,Active,BookContent,Author,EmailId")] Book bookModel);
        Task<Book> EditAsync([Bind("Title,Category,Price,Publisher,Active,BookContent,Author,EmailId")] Book bookmodel, int id);
        Task<Book> DeleteAsync(int id);
        Task<Book> BlockBookAsync(int id);
        Task<Book> UnblockBookAsync(int id);
    }
}
