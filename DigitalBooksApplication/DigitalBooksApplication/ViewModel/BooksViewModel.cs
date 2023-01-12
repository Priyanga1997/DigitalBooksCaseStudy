using BookMicroservice.Models;

namespace BookMicroservice.ViewModel
{
    public class BooksViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
