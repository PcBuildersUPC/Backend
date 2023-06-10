using Microsoft.EntityFrameworkCore;
using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Repositories;
using PcBuilders.Shared.Persistence.Contexts;
using PcBuilders.Shared.Persistence.Repositories;

namespace PcBuilders.Learning.Persistence.Repositories;

public class StoreRepository : BaseRepository, IStoreRepository
{
    public StoreRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Store>> ListAsync()
    {
        return await _context.Stores.ToListAsync();
    }
    
    public async Task<Store> FindByIdAsync(int id)
    {
        return await _context.Stores.FindAsync(id);
    }

    public async Task AddAsync(Store category)
    {
        await _context.Stores.AddAsync(category);
    }
    
    public void Update(Store category)
    {
        _context.Stores.Update(category);
    }

    public void Remove(Store category)
    {
        _context.Stores.Remove(category);
    }
}