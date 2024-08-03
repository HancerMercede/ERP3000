using ERP3000.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ERP3000.Repository;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }

    public DbSet<Order> orders { get; set; }
    public DbSet<Product> products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Order>().ToTable("Orders", "Financials");
        modelBuilder.Entity<Product>().ToTable("Product", "Inventory");
    }
}
