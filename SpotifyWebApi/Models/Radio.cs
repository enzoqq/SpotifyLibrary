using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class Radio
    {
        public int Id { get; set; }
        public string RadioName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? IdGenre { get; set; }

        public virtual Genre IdGenreNavigation { get; set; }
    }
}
