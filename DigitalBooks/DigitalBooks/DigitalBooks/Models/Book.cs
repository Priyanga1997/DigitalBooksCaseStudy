using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DigitalBooks.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }
        public string Publisher { get; set; }
        public string Active { get; set; }
        public string BookContent { get; set; }
        public string Author { get; set; }
        public string EmailId { get; set; }
    }
}
