using System;
using Microsoft.EntityFrameworkCore;
using OtherPerspectivesWebApp.Models;
using SQLitePCL;

namespace OtherPerspectivesWebApp.Data
{
    public sealed class OtherPerspectivesContext : DbContext
    {
        public OtherPerspectivesContext(DbContextOptions<OtherPerspectivesContext> options)
            : base(options)
        {
        }

        public DbSet<InternalUser> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}