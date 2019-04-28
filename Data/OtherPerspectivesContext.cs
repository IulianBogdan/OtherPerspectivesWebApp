using System;
using Microsoft.EntityFrameworkCore;
using OtherPerspectivesWebApp.Models;
namespace OtherPerspectivesWebApp.Data
{
    public sealed class OtherPerspectivesContext : DbContext
    {
        public OtherPerspectivesContext(DbContextOptions<OtherPerspectivesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Item> Items { get; set; }
    }
}