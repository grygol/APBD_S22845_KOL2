using System;
using System.Linq;
using System.Threading.Tasks;
using kol2.Entities.Models;

namespace kol2.Services
{
	public interface IMusicianService
	{
		public IQueryable<Track> GetMusicianPublishedTracks(int musicianId);
		public Task<Musician> GetMusician(int id);
		public Task<bool> DeleteMusician(Musician musician);
	}
}

