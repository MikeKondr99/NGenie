using NGenieBack.Database;
using NGenieBack.Database.Models;

namespace NGenieBack.Repositories;

public record class DocumentRepository(Context Context) 
    : BaseRepository<Document,Guid>(Context, Context.Documents)
{

}
