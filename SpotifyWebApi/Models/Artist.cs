using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
            Songs = new List<Song>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ArtistName { get; set; }

        public virtual List<Album> Albums { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
