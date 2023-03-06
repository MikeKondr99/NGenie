using Microsoft.EntityFrameworkCore;
using NGenieBack.Controllers;
using NGenieBack.Database;
using NGenieBack.Database.Models;
using NGenieBack.Database.Requests;

namespace NGenieBack.Repositories;

public record class BaseRepository<T,TKey>(Context Context,DbSet<T> Table)
    where T : class, IHasKey<TKey>
    where TKey : IComparable<TKey>
{

    private IQueryable<T> qDefault(DbSet<T> table)
    {
        return table;
    }
    public async Task<T?> GetAsync(TKey id,Func<DbSet<T>,IQueryable<T>>? q = null)
    {
        if (q == null) 
            q = qDefault;
        return await q(Table).FirstAsync(x => x.Id.Equals(id));
    }

    public async Task<T?> CreateAsync(ICreateData<T> req)
    {
        var ent = req.Create();
        return await CreateAsync(ent);
    }

    public async Task<T?> CreateAsync(T obj)
    {
        if (await Table.FindAsync(obj.Id) is T ent)
        {
            await Table.AddAsync(obj);
            return obj;
        }
        return null;
    }

    public async Task<T?> UpdateAsync(TKey id,IUpdateData<T> req)
    {
        if (await Table.FindAsync(id) is T ent)
        {
            var newent = req.Update(ent);
            Table.Update(newent);
            await Context.SaveChangesAsync();
            return ent;
        }
        return null;
    }

    public async Task<T?> DeleteAsync(Guid id)
    {
        if (await Table.FindAsync(id) is T ent)
        {
            Table.Remove(ent);
            await Context.SaveChangesAsync();
            return ent;
        }
        return null;
    }
}

public record class DocumentRepository(Context Context) 
    : BaseRepository<Document,Guid>(Context, Context.Documents)
{

}