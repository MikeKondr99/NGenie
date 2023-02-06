using Microsoft.EntityFrameworkCore;
using NGenieBack.Database;
using NGenieBack.Database.Models;
using OneOf;
using OneOf.Types;

namespace NGenieBack.Repositories;

public class DocumentRepository
{
    private readonly Context _context;
    private readonly DbSet<Document> _table;

    public DocumentRepository(Context context)
    {
        _context = context;
        _table = _context.Documents;
    }

    public async Task<Document?> GetAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<Document?> CreateAsync(Document doc)
    {
        if (await _table.FindAsync(doc.Id) is Document)
        {
            return null;
        }
        else
        {
            await _table.AddAsync(doc);
            return doc;
        }

    }

    public async Task<Document?> UpdateAsync(Document doc)
    {
        if (await _table.FindAsync(doc.Id) is Document)
        {
            _table.Update(doc);
            await _context.SaveChangesAsync();
            return doc;
        }
        else
        {
            return null;
        }
    }
    public async Task<Document> DeleteAsync(Guid id)
    {
        if (await _table.FindAsync(id) is Document doc)
        {
            _table.Remove(doc);
            await _context.SaveChangesAsync();
            return doc;
        }
        else
        {
            return null;
        }

    }
}