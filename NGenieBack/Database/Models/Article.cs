using System.ComponentModel.DataAnnotations;

namespace NGenieBack.Database.Models;

public class Article
{
    [Key]
    public Guid Id { get; init; }
}
