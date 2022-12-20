using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class Account
    {
        public Account()
        {
            Playlists = new List<Playlist>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Pw { get; set; }
        public int? IdSubscription { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Subscription IdSubscriptionNavigation { get; set; }
        public virtual List<Playlist> Playlists { get; set; }
    }
}
