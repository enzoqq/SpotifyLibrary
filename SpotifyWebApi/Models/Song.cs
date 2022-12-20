using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public int? IdGenre { get; set; }
        public int? IdArtist { get; set; }
        public int? IdAlbum { get; set; }
        public int? Popularity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PublicationDate { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual Artist IdArtistNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
    }
}
