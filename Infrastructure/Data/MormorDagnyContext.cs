using Core;
using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Purchases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MormorDagnyContext(DbContextOptions<MormorDagnyContext> options) : DbContext(options)
{
    public MormorDagnyContext() : this(new DbContextOptions<MormorDagnyContext>()) { }

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
        builder.Entity<Supplier>().OwnsOne(s => s.Address);


        builder.Entity<SupplierIngredient>(entity =>
        {
            entity.HasOne(si => si.Supplier)
                .WithMany(i => i.SupplierIngredients)
                .HasForeignKey(si => si.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(si => si.Supplier)
                .WithMany(s => s.SupplierIngredients)
                .HasForeignKey(si => si.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }


}
