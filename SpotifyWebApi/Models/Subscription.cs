using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            Accounts = new List<Account>();
        }

        public int Id { get; set; }
        public string SubscriptionName { get; set; }
        public double? Price { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}
