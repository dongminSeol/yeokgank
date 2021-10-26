using Microsoft.EntityFrameworkCore;
using yeokgank.DataScheduler.Model;
using yeokgank.Entities.Apartment;
using yeokgank.Entities.Region;

namespace yeokgank.DataScheduler.Data
{
    public class ConsoleAppDbContext : DbContext
    {
        public DbSet<ApartmentTrade> ApartmentTrade { get; set; }
        public DbSet<RegionCode> RegionCode { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApartmentTrade>().HasKey(c => new { c.TradeCode});
            modelBuilder.Entity<RegionCode>().HasKey(c => new { c.Seq });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("{}");
        }
    }
}
