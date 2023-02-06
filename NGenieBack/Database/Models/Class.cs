using NGenieBack.Controllers;
using System.ComponentModel.DataAnnotations;

namespace NGenieBack.Database.Models;

public class Class : IHasKey<Guid>
{
    [Key]
    public required Guid Id { get; set; }
    public required User Teacher { get; init; }
    public required string Name { get; init; }

    #region EF
    public required string TeacherId { get; init; }
    #endregion
}