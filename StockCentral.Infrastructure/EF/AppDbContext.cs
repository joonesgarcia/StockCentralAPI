using Microsoft.EntityFrameworkCore;
using System.Configuration;
using StockCentral.Domain.Models;

namespace StockCentral.Infrastructure.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Stock { get; set; }
        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<Perfume> Perfumes { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Comission> Comissions { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = StockCentralDBx; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
