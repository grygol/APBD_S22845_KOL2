using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Entities.Models;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kol2.Controllers
{
    [Route("api/[controller]")]
    public class MusiciansController : Controller
    {
        private readonly IMusicianService _musicianService;

        public MusiciansController(IMusicianService service)
        {
            _musicianService = service;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Musician musician = await _musicianService.GetMusician(id);

            if (musician is null) return NotFound();

            if (_musicianService.GetMusicianPublishedTracks(id).Count() > 0) return Conflict();

            await _musicianService.DeleteMusician(musician);
            return Ok("Musician removed");
        }
    }
}

