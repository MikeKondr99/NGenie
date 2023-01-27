using Microsoft.EntityFrameworkCore;
using NGenieBack.Database;
using NGenieBack.Database.Models;

namespace NGenieBack.Repositories;

public class UserRepository
{
    private readonly Context _context;
    private readonly DbSet<User> _table;

    public UserRepository(Context context)
    {
        _context = context;
        _table = _context.Users;
    }

    public GetAllResult<IQueryable<User>> GetAll()
    {
        try
        {
            return _context.Users;
        }
        catch
        {
            return new ServiceUnavaliable();
        }
    }



}