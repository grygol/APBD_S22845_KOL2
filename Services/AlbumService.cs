using System;
using System.Linq;
using System.Threading.Tasks;
using kol2.DTOs;
using kol2.Entities;
using kol2.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services
{
	public class AlbumService : IAlbumService
	{
        private readonly DatabaseContext _context;

		public AlbumService(DatabaseContext context)
		{
            _context = context;
		}

        public IQueryable<Album> GetAlbums(int id)
        {
            return _context.Albums
                .Include(e => e.Tracks)
                .Include(e => e.MusicLabel)
                .Where(e => e.IdAlbum == id);
        }
    }
}

