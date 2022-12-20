using Microsoft.EntityFrameworkCore;
using SpotifyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyWebApi.Utils
{
    public static class SeedData
    {
        public static async Task SeedDatabase(SpotifyContext dbCtx)
        {
            Clear(dbCtx.Artists);
            Clear(dbCtx.Genres);
            Clear(dbCtx.Playlists); 
            Clear(dbCtx.PlaylistSongs);
            Clear(dbCtx.Radios);
            Clear(dbCtx.Albums);
            Clear(dbCtx.Songs);

            List<Artist> artists = new List<Artist>()
            {
                new Artist { ArtistName = "Taylor Swift", Albums = new(), Songs = new() },
                new Artist { ArtistName = "Rihanna", Albums = new(), Songs = new() },
                new Artist { ArtistName = "Katy Perry", Albums = new(), Songs = new() },
                new Artist { ArtistName = "Lady Gaga", Albums = new(), Songs = new() },
                new Artist { ArtistName = "Madonna", Albums = new(), Songs = new() },
                new Artist { ArtistName = "Jay-Z", Albums = new(), Songs = new() }
            };

            List<Album> albums = new List<Album>()
            {
                new Album { AlbumName = "Midnights", Songs = new() },
                new Album { AlbumName = "Loud", Songs = new() },
                new Album { AlbumName = "Teenage Dream", Songs = new() },
                new Album { AlbumName = "Chromatica", Songs = new() },
                new Album { AlbumName = "Erotica", Songs = new() },
                new Album { AlbumName = "The Blueprint", Songs = new() }
            };

            List<Song> songs = new List<Song>()
            {
                new Song { SongName = "Lavender Haze", Popularity = 10 },
                new Song { SongName = "Anti-Hero", Popularity = 20 },
                new Song { SongName = "Midnight Rain", Popularity = 30 },
                new Song { SongName = "Maroon", Popularity = 40 },
                new Song { SongName = "Vigilante Shit", Popularity = 50 },
                new Song { SongName = "Question", Popularity = 100 },

                new Song { SongName = "Lavender Haze", Popularity = 10 },
                new Song { SongName = "Anti-Hero", Popularity = 20 },
                new Song { SongName = "Midnight Rain", Popularity = 30 },
                new Song { SongName = "Maroon", Popularity = 40 },
                new Song { SongName = "Vigilante Shit", Popularity = 50 },
                new Song { SongName = "Question", Popularity = 100 },

                new Song { SongName = "Peacock", Popularity = 10 },
                new Song { SongName = "ET", Popularity = 20 },
                new Song { SongName = "Circle the Drain", Popularity = 30 },
                new Song { SongName = "Firework", Popularity = 40 },
                new Song { SongName = "Pearl", Popularity = 50 },
                new Song { SongName = "California Gurls", Popularity = 100 },

                new Song { SongName = "Chromatica I", Popularity = 10 },
                new Song { SongName = "Chromatica II", Popularity = 20 },
                new Song { SongName = "Rain On Me", Popularity = 30 },
                new Song { SongName = "Alice", Popularity = 40 },
                new Song { SongName = "Free Woman", Popularity = 50 },
                new Song { SongName = "911", Popularity = 100 },

                new Song { SongName = "Erotica", Popularity = 10 },
                new Song { SongName = "Fever", Popularity = 20 },
                new Song { SongName = "Bye Bye Baby", Popularity = 30 },
                new Song { SongName = "Deeper and Deeper", Popularity = 40 },
                new Song { SongName = "Bad Girl", Popularity = 50 },
                new Song { SongName = "Words", Popularity = 100 },

                new Song { SongName = "Takeover", Popularity = 10 },
                new Song { SongName = "Never Change", Popularity = 20 },
                new Song { SongName = "Renegade", Popularity = 30 },
                new Song { SongName = "Song Cry", Popularity = 40 },
                new Song { SongName = "All I Need", Popularity = 50 },
                new Song { SongName = "Blueprint", Popularity = 100 }
            };

            List<Subscription> subscriptions = new List<Subscription>()
            {
                new Subscription { Price = 0, SubscriptionName = "Free", Accounts = new() },
                new Subscription { Price = 5, SubscriptionName = "Premium", Accounts = new() }
            };

            Account account = new Account { Email = "testemail@amail.com", Pw = "testpassword", Username = "TestUsername", Playlists = new() };

            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist { PlaylistName = "Pop Music" }
            };

            List<Genre> genres = new List<Genre>()
            {
                new Genre { GenreName = "Rock", Albums = new(), Radios = new(), Songs = new() },
                new Genre { GenreName = "Pop", Albums = new(), Radios = new(), Songs = new()  },
                new Genre { GenreName = "Heavy Metal", Albums = new(), Radios = new(), Songs = new()  },
                new Genre { GenreName = "Jazz", Albums = new(), Radios = new(), Songs = new()  },
                new Genre { GenreName = "Electronic", Albums = new(), Radios = new(), Songs = new()  },
                new Genre { GenreName = "Soul", Albums = new(), Radios = new(), Songs = new()  }
            };

            List<Radio> radios = new List<Radio>()
            {
                new Radio { RadioName = "Rock 2022" },
                new Radio { RadioName = "Pop 2022" },
                new Radio { RadioName = "Heavy Metal 2022" },
                new Radio { RadioName = "Jazz 2022" },
                new Radio { RadioName = "Electronic 2022" },
                new Radio { RadioName = "Soul 2022" },
            };

            for (int i = 0; i < artists.Count; i++)
                artists[i].Albums.Add(albums[i]);


            int j = 0;
            foreach (var art in artists)
            {
                art.Songs.Add(songs[j]);
                art.Songs.Add(songs[j + 1]);
                art.Songs.Add(songs[j + 2]);
                art.Songs.Add(songs[j + 3]);
                art.Songs.Add(songs[j + 4]);
                art.Songs.Add(songs[j + 5]);

                j += 6;
            }







            account.Playlists = playlists;

            dbCtx.Accounts.Add(account);
            dbCtx.Artists.AddRange(artists);
            dbCtx.Albums.AddRange(albums);
            dbCtx.Songs.AddRange(songs);
            dbCtx.Radios.AddRange(radios);
            dbCtx.Subscriptions.AddRange(subscriptions);
            dbCtx.Genres.AddRange(genres);
            dbCtx.Playlists.AddRange(playlists);


            try
            {
                await dbCtx.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


            public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            if (dbSet.Any())
                dbSet.RemoveRange(dbSet.ToList());

        }
    }
}
