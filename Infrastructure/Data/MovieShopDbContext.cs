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
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);

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

        private void ConfigureUserRole(EntityTypeBuilder<UserRole> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureUser(EntityTypeBuilder<User> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureRole(EntityTypeBuilder<Role> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureReview(EntityTypeBuilder<Review> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> obj)
        {
            throw new NotImplementedException();
        }
    }
}
