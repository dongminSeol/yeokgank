using Microsoft.EntityFrameworkCore;
using yeokgank.Entities.Apartment;
using yeokgank.Entities.Region;
namespace yeokgank.Repository
{
    public class yeokgankDbContext : DbContext
    {
        public yeokgankDbContext(DbContextOptions<yeokgankDbContext> options) : base(options)
        {
            
        }
        public DbSet<RegionCode> RegionCode { get; set; }
        public DbSet<ApartmentTrade> ApartmentTrade { get; set; }

    }
}
