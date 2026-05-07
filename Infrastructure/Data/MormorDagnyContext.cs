using Core;
using Core.Entities;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MormorDagnyContext(DbContextOptions options) : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierIngredient> SupplierIngredients { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Customer>().OwnsOne(c => c.DeliveryAddress);
        builder.Entity<Customer>().OwnsOne(c => c.InvoiceAddress);
        builder.Entity<Order>().HasMany(c => c.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Order>().Property(c => c.OrderDate).HasConversion(
            c => c.ToUniversalTime(),
            c => DateTime.SpecifyKind(c, DateTimeKind.Utc)
        );

        builder.Entity<OrderItem>().OwnsOne(c => c.ItemOrdered, i => i.WithOwner());
    }


}
