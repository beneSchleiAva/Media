using Microsoft.EntityFrameworkCore;

namespace Persistence.Entities.Concrete.Context
{
    public class EntityContext : DbContext
    {
        const string dbName = "ReactDb";
        public DbSet<ProductEntity>? Products { get; set; }
        public DbSet<OrderEntity>? Orders { get; set; }
        public DbSet<OrderPositionEntity>? OrderPositions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database={dbName};Trusted_Connection=True;");
        }
    }
}
