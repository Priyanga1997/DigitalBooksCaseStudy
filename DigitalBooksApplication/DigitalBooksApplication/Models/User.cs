using System;
using System.Collections.Generic;

namespace BookMicroservice.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? EmailId { get; set; }

    public string? Password { get; set; }

    public string? UserType { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();

    public virtual ICollection<Subscription> Subscriptions { get; } = new List<Subscription>();
}
