using System;
using System.Collections.Generic;

namespace UserMicroservice.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? Image { get; set; }

    public int? Price { get; set; }

    public string? Publisher { get; set; }

    public string? Active { get; set; }

    public string? BookContent { get; set; }

    public string? Author { get; set; }

    public string? EmailId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; } = new List<Subscription>();

    public virtual User? User { get; set; }
}
