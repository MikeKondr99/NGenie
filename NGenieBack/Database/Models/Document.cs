using NGenieBack.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NGenieBack.Database.Models;

public class Document : IHasKey<Guid>
{
    [Key]
    public required Guid Id { get; set; }
    public User Owner { get; set; }

    public Class? Class { get; set; }
    public int OrderInClass { get; set; }

    public required string Title { get; set; }
    public required string Text { get; set; }

    #region EF
    [IgnoreDataMember]
    public required string OwnerId { get; set; }
    #endregion
}
