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
    }
}