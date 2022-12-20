using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpotifyWebApi.Models
{
    public partial class SpotifyContext : DbContext
    {
        public SpotifyContext()
        {
        }

        public SpotifyContext(DbContextOptions<SpotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public virtual DbSet<Radio> Radios { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Spotify; User id = sa ; password = Pass@word01;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdSubscription).HasColumnName("id_subscription");

                entity.Property(e => e.Pw)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("pw");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdSubscriptionNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdSubscription)
                    .HasConstraintName("FK__account__id_subs__398D8EEE");
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("album_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdArtist).HasColumnName("id_artist");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdArtist)
                    .HasConstraintName("FK__album__id_artist__440B1D61");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdGenre)
                    .HasConstraintName("FK__album__id_genre__44FF419A");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("artist_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("playlist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAccount).HasColumnName("id_account");

                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("playlist_name");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK__playlist__id_acc__47DBAE45");
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.ToTable("playlist_songs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPlaylist).HasColumnName("id_playlist");

                entity.Property(e => e.IdSong).HasColumnName("id_song");
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.ToTable("radio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.RadioName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("radio_name");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Radios)
                    .HasForeignKey(d => d.IdGenre)
                    .HasConstraintName("FK__radio__id_genre__5535A963");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("song");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAlbum).HasColumnName("id_album");

                entity.Property(e => e.IdArtist).HasColumnName("id_artist");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.Popularity).HasColumnName("popularity");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publication_date");

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("song_name");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.IdAlbum)
                    .HasConstraintName("FK__song__id_album__5070F446");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.IdArtist)
                    .HasConstraintName("FK__song__id_artist__4F7CD00D");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.IdGenre)
                    .HasConstraintName("FK__song__id_genre__4E88ABD4");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SubscriptionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("subscription_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
