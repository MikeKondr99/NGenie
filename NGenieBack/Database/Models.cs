using NGenieBack.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NGenieBack.Database.Models;


public record Class : IHasKey<Guid>
{ 
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string TeacherId { get; set; }
    public required User Teacher { get; set; }
}



public record User : IHasKey<string>
{
    [Key]
    public required string Id { get; set; }
    public required UserRole Roles { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Avatar { get; set; }
    [IgnoreDataMember]
    public required string PasswordHash { get; init; }
    [IgnoreDataMember]
    public required byte[] PasswordSalt { get; init; }
}


[Flags]
public enum UserRole
{
    None = 0,
    Student = 1,
    Teacher = 2,
    Admin = 4,
}

public record Document : IHasKey<Guid>
{
    public required Guid Id { get; set; }
    public required User Owner { get; set; }
    public required Class? Class { get; set; }
    public required int OrderInClass { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
    [IgnoreDataMember] 
    public required string OwnerId { get; init; }
}
