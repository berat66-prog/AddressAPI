using Microsoft.EntityFrameworkCore;
using AddressAPI.Model;

namespace AddressAPI.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
    }
}
