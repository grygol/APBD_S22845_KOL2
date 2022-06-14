using System;
using System.Collections.Generic;
using System.Linq;
using kol2.Entities.Models;

namespace kol2.DTOs
{
	public class AlbumGet
	{
		public int IdAlbum { get; set; }
		public string AlbumName { get; set; }
		public DateTime PublishDate { get; set; }
		public string MusicLabelName { get; set; }
        public List<TrackGet> Tracks { get; set; }
    }
}

