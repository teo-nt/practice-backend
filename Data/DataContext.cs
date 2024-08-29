using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMovie> OrderMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderMovie>().HasKey(["OrderId", "MovieId"]);
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders);
            modelBuilder.Entity<OrderMovie>().HasOne(om => om.Order).WithMany(o => o.OrderMovies);
            modelBuilder.Entity<OrderMovie>().HasOne(om => om.Movie).WithMany(m => m.OrderMovies);
            
        }

    }
}
