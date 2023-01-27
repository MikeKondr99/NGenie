using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using NGenieBack.Auth;
using NGenieBack.Database.Models;
using NGenieBack.Primitives;
using SQLitePCL;
using System.Reflection.Emit;

namespace NGenieBack.Database;

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
        // Настройка
        modelBuilder.Entity<User>().Property(b => b.Roles).HasConversion(
            r => String.Join(", ", r),
            s => s.Split(',',StringSplitOptions.None).Select(x => (UserRole)Enum.Parse<UserRole>(x.Trim())).ToArray()
        );

        // Заполняем
        const string LOCALE = "ru";
        var users = new Faker<User>(LOCALE)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Id, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.PasswordSalt, f => PasswordHashing.GenSalt())
            .RuleFor(u => u.Avatar, f=>f.Internet.Avatar().OrNull(f,0.3f))
            .RuleFor(u => u.PasswordHash, (f, u) => PasswordHashing.HashString(
                f.Internet.Password(
                    f.Random.Number(8, 25), // Длина пароля
                    f.Random.Bool(0.3f)),  // Запоминающийся 30%
                u.PasswordSalt))
            .RuleFor(u => u.Roles, f => new UserRole[] { f.PickRandomWithout(UserRole.Admin) })
            .GenerateBetween(40, 60);

        var teachers = users.Where(u => u.Roles.Contains(UserRole.Teacher)).ToList();

        var articles = new Faker<Article>(LOCALE)
            .RuleFor(a => a.Id, f => f.Random.Guid())
            .RuleFor(a => a.OwnerId, f => f.PickRandom(teachers).Id)
            .RuleFor(a => a.Text, f =>
                $"# {f.Hacker.Phrase()}\n" +
                $"{f.Lorem.Text()}"
            )
            .GenerateBetween(60, 80);
            



            

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Article>().HasData(articles);
    }
}
