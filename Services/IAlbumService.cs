using System;
using System.Linq;
using System.Threading.Tasks;
using kol2.DTOs;
using kol2.Entities.Models;

namespace kol2.Services
{
	public interface IAlbumService
	{
		public IQueryable<Album> GetAlbums(int id);

	}
}

