using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace NGenieBack.Database.Models;

public class User
{
    [Key]
    public required string Username { get; init; }
    public required string Password { get; init; } // for debug
    public required string PasswordHash { get; init; }
    public required byte[] PasswordSalt { get; init; }
}
