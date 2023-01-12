using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalBooksAppln.Models;

public partial class Book
{
    public int BookId { get; set; }

    //[Required]
    public string? Title { get; set; }
    //[Required]
    public string? Category { get; set; }

    public string? Image { get; set; }
    //[Required]
    public int? Price { get; set; }
    //[Required]
    public string? Publisher { get; set; }
    //[Required]
    public string? Active { get; set; }
    //[Required]
    public string? BookContent { get; set; }
    //[Required]
    public string? Author { get; set; }

    public string? EmailId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; } = new List<Subscription>();

    public virtual User? User { get; set; }
}
