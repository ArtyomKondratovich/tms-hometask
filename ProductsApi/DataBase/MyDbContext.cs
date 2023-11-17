using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.DataBase
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<StorageModel> Storages { get; set; }
    }
}
