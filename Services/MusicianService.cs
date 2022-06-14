using System;
using System.Linq;
using System.Threading.Tasks;
using kol2.Entities;
using kol2.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services
{
	public class MusicianService : IMusicianService
	{
        private readonly DatabaseContext _context;

        public MusicianService(DatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<Track> GetMusicianPublishedTracks(int musicianId)
        {
            //return _context.Musician_Tracks
            //    .Where(e => e.IdMusician == musicianId)
            //    .Include(e => e.Track)
            //    .ThenInclude(e => e.Album)
            //    .Select(e => e.Track).Where(e => e.Album.PublishDate > DateTime.Now);

            return _context.Musician_Tracks
                .Where(e => e.IdMusician == musicianId)
                .Include(e => e.Track)
                .Select(e => e.Track).Where(e => e.IdMusicAlbum != null);
        }

        public async Task<Musician> GetMusician(int id)
        {
            return await _context.Musicians.Where(e => e.IdMusician == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteMusician(Musician musician)
        {
            _context.Entry(musician).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

