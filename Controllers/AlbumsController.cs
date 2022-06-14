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

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var albums = _albumService.GetAlbums(id);

            if (albums.Count() == 0) return NotFound();

            var result = albums.Select(e => new AlbumGet
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
            });

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

