using Microsoft.EntityFrameworkCore;
using PcBuilders.Learning.Domain.Model;

namespace PcBuilders.Shared.Persistence.Contexts;

public class AppDbContext :DbContext
{
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Store>().ToTable("Stores");
        builder.Entity<Store>().HasKey(p => p.Id);
        builder.Entity<Store>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Store>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        
        // Relationships
        builder.Entity<Store>()
            .HasMany(p => p.Products)
            .WithOne(p => p.Store)
            .HasForeignKey(p => p.StoreId);
        
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(120);
    }
}