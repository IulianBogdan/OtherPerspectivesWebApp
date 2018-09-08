using System;
using Microsoft.EntityFrameworkCore;

namespace OtherPerspectivesWebApp.Models
{
    public sealed class OtherPerspectivesContext : DbContext
    {
        public OtherPerspectivesContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Painting> Paintings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}