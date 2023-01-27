using NGenieBack.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NGenieBack.Database.Models;

public class Article : IHasKey<Guid>
{
    [Key]
    public required Guid Id { get; set; }

    [IgnoreDataMember]
    public required string OwnerId { get; init; }
    public required User Owner { get; init; }
    public required string Text { get; init; }
}
