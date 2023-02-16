using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.OData.ModelBuilder;
using NGenieBack.Auth;
using NGenieBack.Database.Models;
using SQLitePCL;
using System.Reflection.Emit;

namespace NGenieBack.Database;

public class Context : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Document> Documents => Set<Document>();

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
            s => Enum.Parse<UserRole>(s)
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
            .RuleFor(u => u.Roles, f => f.PickRandom(new UserRole[] {UserRole.Teacher,UserRole.Student}))
            .GenerateBetween(40, 60);

        var teachers = users.Where(u => u.Roles.HasFlag(UserRole.Teacher)).ToList();

        string[] files = Directory.GetFiles("files/").ToArray();
        var iter = files.AsEnumerable().GetEnumerator();

        var documents = new Faker<Document>(LOCALE)
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(d => d.OwnerId, (f, d) => f.PickRandom(teachers).Id)
            .RuleFor(d => d.Title, f => { iter.MoveNext(); return Path.GetFileNameWithoutExtension(iter.Current); })
            .RuleFor(d => d.Text, f => File.ReadAllText(iter.Current));
            //.RuleFor(d => d.Class)  // null
            //.RuleFor(d => d.OrderInClass)  // 0


        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Document>().HasData(documents);
    }

}
