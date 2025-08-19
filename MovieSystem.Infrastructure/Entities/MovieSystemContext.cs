using Microsoft.EntityFrameworkCore;
using MovieSystem.Core.Models;
using System.IO;

namespace MovieSystem.Infrastructure.Data
{
    public class MovieSystemContext : DbContext
    {
        public MovieSystemContext(DbContextOptions<MovieSystemContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MovieId);
        }
    }
}
