using Microsoft.EntityFrameworkCore;
using TravelApiSql.Models;

namespace TravelApiSql.Data
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {
        }

        public DbSet<Destination> Destinations => Set<Destination>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>().ToTable("Destination");
        }
    }
}
