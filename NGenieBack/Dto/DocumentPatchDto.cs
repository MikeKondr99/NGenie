
using NGenieBack.Database.Models;

namespace NGenieBack.Dto;

public class DocumentPatchDto : IPatchDto<Document>
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? OwnerId { get; set; }

    public Document Patch(Document entity)
    {
        entity.Title = Title ?? entity.Title;
        entity.Text = Text ?? entity.Text;
        entity.OwnerId = OwnerId ?? entity.OwnerId;
        return entity;
    }


}