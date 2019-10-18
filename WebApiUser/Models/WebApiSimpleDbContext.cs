using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiUser.Models
{
    public partial class WebApiSimpleDbContext : DbContext
    {
        public WebApiSimpleDbContext()
        {
        }

        public WebApiSimpleDbContext(DbContextOptions<WebApiSimpleDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=local.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
