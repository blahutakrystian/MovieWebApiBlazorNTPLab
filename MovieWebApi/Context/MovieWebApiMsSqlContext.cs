using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Model;

namespace MovieWebApi.Context
{
    public class MovieWebApiMsSqlContext : DbContext
    {
        public MovieWebApiMsSqlContext(DbContextOptions<MovieWebApiMsSqlContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>() // one to many: one director → many movies
                .HasOne<Director>(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);
            modelBuilder.Entity<Movie>() // one to many: one movie → many reviews
                .HasMany<Review>(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);
            modelBuilder.Entity<Review>()
                .Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Review>()
                .Property(r => r.Rate)
                .IsRequired();

        }
    }
}
