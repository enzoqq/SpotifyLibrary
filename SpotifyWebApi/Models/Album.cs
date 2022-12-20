using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? IdArtist { get; set; }
        public int? IdGenre { get; set; }
        public string AlbumName { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
