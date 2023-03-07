using NGenieBack.Database;
using NGenieBack.Database.Models;

namespace NGenieBack.Repositories;

public record class UserRepository(Context Context) 
    : BaseRepository<User,string>(Context, Context.Users)
{

}