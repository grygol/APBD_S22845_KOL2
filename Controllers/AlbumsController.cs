using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.DTOs;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kol2.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {

        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var result = await _albumService.GetAlbums(id).Select(e => new AlbumGet
            {
                IdAlbum = e.IdAlbum,
                AlbumName = e.AlbumName,
                PublishDate = e.PublishDate,
                MusicLabelName = e.MusicLabel.Name,
                Tracks = e.Tracks.Select(e => new TrackGet
                {
                    IdTrack = e.IdTrack,
                    TrackName = e.TrackName,
                    Duration = e.Duration
                }).OrderBy(e => e.Duration).ToList()
            }).FirstOrDefaultAsync();


            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}

