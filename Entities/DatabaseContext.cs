using System;
using kol2.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Entities
{
	public class DatabaseContext : DbContext
	{
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
		public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Musician>(e =>
			{
				e.HasKey(e => e.IdMusician);

				e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
				e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
				e.Property(e => e.Nickname).HasMaxLength(20).IsRequired(false);

				e.HasData(
					new Musician
					{
						IdMusician = 1,
						FirstName = "Muzyk",
						LastName = "A",
						Nickname = "Pierwszy"
					},
					new Musician
                    {
						IdMusician = 2,
						FirstName = "Muzyk",
						LastName = "B",
						Nickname = "Drugi"
                    });

				e.ToTable("Musician");
			});

			modelBuilder.Entity<Musician_Track>(e =>
			{
				e.HasKey(e => new { e.IdTrack, e.IdMusician });

				e.HasOne(e => e.Musician)
				.WithMany(e => e.Musician_Tracks)
				.HasForeignKey(e => e.IdMusician)
				.OnDelete(DeleteBehavior.ClientSetNull);

				e.HasOne(e => e.Track)
				.WithMany(e => e.Musician_Tracks)
				.HasForeignKey(e => e.IdTrack)
				.OnDelete(DeleteBehavior.Cascade);

				e.HasData(
					new Musician_Track
					{
						IdTrack = 1,
						IdMusician = 1
					});

				e.ToTable("Musician_Track");
			});

			modelBuilder.Entity<Track>(e =>
			{
				e.HasKey(e => e.IdTrack);

				e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
				e.Property(e => e.Duration).IsRequired();

				e.HasOne(e => e.Album)
				.WithMany(e => e.Tracks)
				.HasForeignKey(e => e.IdMusicAlbum)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Cascade);

				e.HasData(new Track
				{
					IdTrack = 1,
					TrackName = "Utwor",
					Duration = 3.5f,
					IdMusicAlbum = 1
				});

				e.ToTable("Track");
			});

			modelBuilder.Entity<Album>(e =>
			{
				e.HasKey(e => e.IdAlbum);

				e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
				e.Property(e => e.PublishDate).IsRequired();

				e.HasOne(e => e.MusicLabel)
				.WithMany(e => e.Albums)
				.HasForeignKey(e => e.IdMusicLabel)
				.OnDelete(DeleteBehavior.Cascade);

				e.HasData(new Album
				{
					IdAlbum = 1,
					AlbumName = "Album Pierwszy",
					PublishDate = DateTime.Now,
					IdMusicLabel = 1
				});

				e.ToTable("Album");
			});

			modelBuilder.Entity<MusicLabel>(e =>
			{
				e.HasKey(e => e.IdMusicLabel);

				e.Property(e => e.Name).HasMaxLength(50).IsRequired();

				e.HasData(new MusicLabel
				{
					IdMusicLabel = 1,
					Name = "Label Pierwszy"
				});

				e.ToTable("MusicLabel");
			});
        }



	}
}

