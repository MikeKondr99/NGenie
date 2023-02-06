using NGenieBack.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NGenieBack.Database.Models;

public class User : IHasKey<string>
{
    [Key]
    public required string Id { get; set; }

    public required UserRole Roles { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? Avatar { get; init; }

    // Password internals
    [IgnoreDataMember]
    public required string PasswordHash { get; init; }

    [IgnoreDataMember]
    public required byte[] PasswordSalt { get; init; }
}
