using System;
using System.Collections.Generic;

namespace BookMicroservice.Models;

public partial class Subscription
{
    public int SubscriptionId { get; set; }

    public int? BookId { get; set; }

    public string? Title { get; set; }

    public string? EmailId { get; set; }

    public string? SubscriptionActive { get; set; }

    public int? UserId { get; set; }

    public string? Author { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
