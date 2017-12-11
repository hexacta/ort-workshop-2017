using Microsoft.EntityFrameworkCore;
using OrtWorkshopBackend.Data.Entities;

namespace OrtWorkshopBackend.Data
{
    public class OrtWorkshopContext: DbContext
    {
        public OrtWorkshopContext(DbContextOptions<OrtWorkshopContext> options) : base(options)
        {
        }        

        public DbSet<Movie> Movie { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
        }
    }
}