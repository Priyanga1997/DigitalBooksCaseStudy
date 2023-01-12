using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctions.Models
{
    internal class Subscription
    {
        public int SubscriptionId { get; set; }

        public int? BookId { get; set; }

        public string? Title { get; set; }

        public string? EmailId { get; set; }

        public string? SubscriptionActive { get; set; }

        public int? UserId { get; set; }

        public string? Author { get; set; }
    }
}
