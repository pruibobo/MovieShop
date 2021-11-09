using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        //DbSets as properties

        public DbSet<Cast> Casts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        // Use Fluent API to create relationships and constraints

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            // modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre); EF will automatically create
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<User>(ConfigureUser);
            // modelBuilder.Entity<UserRole>(ConfigureUserRole); EF will automatically create

            // Create many-to-many relationships using junction table
            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>("MovieGenre",
                    m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>("UserRoles",
                    u => u.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    r => r.HasOne<User>().WithMany().HasForeignKey("UserId"));


        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.DateOfBirth).HasColumnType("datetime2(7)");
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.TwoFactorEnabled);
            builder.Property(u => u.LockoutEndDate).HasColumnType("datetime2(7)");
            builder.Property(u => u.LastLoginDateTime).HasColumnType("datetime2(7)");
            builder.Property(u => u.IsLocked);
            builder.Property(u => u.AccessFailedCount);
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name);
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new { r.UserId, r.MovieId });
            builder.HasOne(r => r.Movie).WithMany(m => m.Reviews).HasForeignKey(r => r.MovieId);
            builder.HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId);
            builder.Property(r => r.Rating).HasColumnType("decimal(3,2)").HasDefaultValue(9.9m);
            builder.Property(r => r.ReviewText).HasMaxLength(2084);
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserId);
            builder.Property(p => p.PurchaseNumber).HasColumnType("UniqueIdentifier");
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18,2)").HasDefaultValue(9.9m);
            builder.Property(p => p.PurchaseDateTime).HasColumnType("datetime2(7)");
            builder.Property(p => p.MovieId);
        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new { mc.CrewId, mc.MovieId, mc.Department, mc.Job });
            builder.HasOne(mc => mc.Movie).WithMany(m => m.MovieCrews).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Crew).WithMany(c => c.MovieCrews).HasForeignKey(mc => mc.CrewId);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character });
            builder.HasOne(mc => mc.Movie).WithMany(m => m.MovieCasts).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast).WithMany(c => c.MovieCasts).HasForeignKey(mc => mc.CastId);
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.Budget).HasColumnType("decimal(18,2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18,2)").HasDefaultValue(9.9m);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmbdUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5,2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreateDate).HasDefaultValue("getdate()");
            builder.Ignore(m => m.Rating);
        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(64);
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.MovieId);
            builder.Property(f => f.UserId);
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.Gender).HasMaxLength(2084);
            builder.Property(c => c.TmdbUrl).HasMaxLength(2084);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.Gender).HasMaxLength(2084);
            builder.Property(c => c.TmdbUrl).HasMaxLength(2084);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }
    }
}
