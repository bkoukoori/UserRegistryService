using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UserRegistryService.DBContext
{
	public class UserDbContext: DbContext
	{
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }

        public DbSet<UserProfile> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }

    }
}

