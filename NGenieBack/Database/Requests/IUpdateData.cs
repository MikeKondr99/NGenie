using NGenieBack.Database.Models;

namespace NGenieBack.Database.Requests;

public interface IUpdateData<T>
{
    T Update(T data);
}

public class UpdateDocument : IUpdateData<Document>
{
    public string? Title { get; set; }
    public string? Text { get; set; }

    public Document Update(Document data)
    {
        data.Title = this.Title ?? data.Title;
        data.Text = this.Text ?? data.Text;
        return data;
    }
}
