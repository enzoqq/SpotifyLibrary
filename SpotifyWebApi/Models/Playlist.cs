using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class Playlist
    {
        public int Id { get; set; }
        public int? IdAccount { get; set; }
        public string PlaylistName { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
    }
}
