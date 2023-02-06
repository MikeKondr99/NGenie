using NGenieBack.Database.Models;

namespace NGenieBack.Dto;

public class DocumentPostDto : IPostDto<Document>
{
    public required string OwnerId { get; init; }
    public required string Title { get; init; }

    public Document Create()
    {
        return new Document()
        {
            Id = Guid.NewGuid(),
            Title = Title,
            OwnerId = OwnerId,
            Text = "",
        };
    }
}