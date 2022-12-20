using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotifyWebApi.Models;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SpotifyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly ILogger<SpotifyController> _logger;
        private readonly IMapper _mapper;
        private readonly SpotifyContext _context;
        public SpotifyController(ILogger<SpotifyController> logger, SpotifyContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        [HttpGet("GetSongs")]
        public async Task<IActionResult> GetSongs()
        {
            try
            {
                var songs = await _context.Songs.ToListAsync();

                return Ok(songs);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        [HttpGet("GetGenres")]
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                var genres = await _context.Genres.ToListAsync();

                return Ok(genres);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        [HttpGet("GetArtists")]
        public async Task<IActionResult> GetArtists()
        {
            try
            {
                var artists = await _context.Artists.ToListAsync();

                return Ok(artists);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        [HttpGet("GetAlbums")]
        public async Task<IActionResult> GetAlbums()
        {
            try
            {
                var albums = await _context.Albums.ToListAsync();

                return Ok(albums);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

        }

        [HttpGet("GetRadios")]
        public async Task<IActionResult> GetRadios()
        {
            try
            {
                var radios = await _context.Radios.ToListAsync();

                return Ok(radios);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

        }

        [HttpGet("GetPlaylists")]
        public async Task<IActionResult> GetPlaylists()
        {
            try
            {
                var playlists = await _context.Playlists.ToListAsync();

                return Ok(playlists);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

        }

        [HttpGet("GetPlaylistsSongs")]
        public async Task<IActionResult> GetPlaylistsSongs()
        {
            try
            {
                var playlistsSongs = await _context.PlaylistSongs.ToListAsync();

                return Ok(playlistsSongs);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

        }

        [HttpGet("GetAccount")]
        public async Task<IActionResult> GetAccount()
        {
            try
            {
                var accounts = await _context.Accounts.ToListAsync();

                return Ok(accounts);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

        }

        [HttpGet("GetIdSongByName/{Name}")]
        public async Task<IActionResult> GetIdSongByName(string Name)
        {
            Song s;
            using (_context)
            {
                try
                {
                    s = await _context.Songs.Where(c => c.SongName == Name).FirstAsync();
                    return Ok(s);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}
