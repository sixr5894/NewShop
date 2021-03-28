using Microsoft.EntityFrameworkCore;
using Shop.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class Context : DbContext
    {
        public DbSet<ProductModel> ProductModelsList { get; set; }
        public DbSet<AuthorizationModel> AuthModelsList { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel()
                {
                    Name = "SeedProduct",
                    ImagePath = "https://theworldtravelguy.com/wp-content/uploads/2018/12/DSCF2631-2.jpg",
                    ID = "SeedID",
                    Price = 110
                }
                );
            modelBuilder.Entity<AuthorizationModel>().HasData(
                new AuthorizationModel() {
                Login = "user",
                Password = "user"
                }
                );
        }
    }
}
