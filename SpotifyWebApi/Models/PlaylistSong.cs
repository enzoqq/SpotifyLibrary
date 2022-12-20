using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class PlaylistSong
    {
        public int Id { get; set; }
        public int? IdSong { get; set; }
        public int? IdPlaylist { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
