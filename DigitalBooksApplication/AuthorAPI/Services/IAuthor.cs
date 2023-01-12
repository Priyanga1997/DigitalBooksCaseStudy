//using Microsoft.AspNetCore.Mvc;

//namespace AuthorAPI.Services
//{
//    public interface IAuthor
//    {
//        IEnumerable<Book> Index();
//        IEnumerable<Book> Details(string emailId);
//        Task<Book> CreateAsync([Bind("Title,Category,Image,Price,Publisher,Active,BookContent,Author,EmailId")] BookModel bookModel, string dbPath);
//        Task<Book> EditAsync([Bind("Title,Category,Image,Price,Publisher,Active,BookContent,Author,EmailId")] BookModel bookmodel, int id);
//        Task<Book> DeleteAsync(int id);
//        Task<Book> BlockBookAsync(int id);
//        Task<Book> UnblockBookAsync(int id);
//    }
//}
