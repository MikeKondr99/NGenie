using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using NGenieBack.Auth;
using NGenieBack.Database.Models;
using SQLitePCL;
using System.Reflection.Emit;

namespace NGenieBack.Database
{
    public class Context : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Article> Articles => Set<Article>();

        public Context()
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.Database.EnsureCreated();
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var fake = new Faker<User>()
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.PasswordSalt, f => PasswordHashing.GenSalt())
                .RuleFor(u => u.PasswordHash, (f, u) => PasswordHashing.HashString(u.Password, u.PasswordSalt));
            modelBuilder.Entity<User>().HasData(fake.GenerateBetween(40, 60));
        }
    }
}
