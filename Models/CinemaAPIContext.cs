using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class CinemaAPIContext : DbContext
    {
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<DirectorMovie> DirectorMovies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public CinemaAPIContext(DbContextOptions<CinemaAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}