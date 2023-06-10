using Microsoft.EntityFrameworkCore;
using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Domain.Repositories;
using PcBuilders.Shared.Persistence.Contexts;
using PcBuilders.Shared.Persistence.Repositories;

namespace PcBuilders.Learning.Persistence.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.Include(p => p.Store)
            .ToListAsync();
    }

    public async Task<Product> FindByIdAsync(int productId)
    {
        return await _context.Products
            .Include(p => p.Store)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<Product> FindByNameAsync(string name)
    {
        return await _context.Products
            .Include(p => p.Store)
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Product>> FindByStoreIdAsync(int storeId)
    {
        return await _context.Products
            .Where(p => p.StoreId == storeId)
            .Include(p => p.Store)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}