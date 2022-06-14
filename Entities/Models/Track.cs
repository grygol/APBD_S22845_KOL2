﻿using System;
using System.Collections.Generic;

namespace kol2.Entities.Models
{
	public class Track
	{
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }
        public virtual IEnumerable<Musician_Track> Musician_Tracks  { get; set; }
        public virtual Album Album { get; set; }
    }
}

