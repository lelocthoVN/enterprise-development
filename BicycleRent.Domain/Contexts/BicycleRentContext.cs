using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Domain.Contexts;

/// <summary>
/// Database context for managing bicycle rental system
/// </summary>
public class BicycleRentContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BicycleType> BicycleTypes { get; set; }
    public DbSet<Bicycle> Bicycles { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    public BicycleRentContext(DbContextOptions<BicycleRentContext> options)
        : base(options) { }
    
    /// <summary>
    /// Configures the model relationships using Fluent API
    /// </summary>
    /// <param name="modelBuilder">Model builder instance</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Declare primary keys for tables
        modelBuilder.Entity<Bicycle>().HasKey(b => b.SerialNumber);  
        modelBuilder.Entity<Customer>().HasKey(c => c.Id);  
        modelBuilder.Entity<BicycleType>().HasKey(bt => bt.Id);  
        modelBuilder.Entity<Rental>().HasKey(r => r.Id);

        // Configure required properties
        modelBuilder.Entity<Bicycle>()
            .Property(b => b.SerialNumber)
            .IsRequired();  
        modelBuilder.Entity<Bicycle>()
            .Property(b => b.Color)
            .IsRequired();  
        modelBuilder.Entity<Bicycle>()
            .Property(b => b.Model)
            .IsRequired();
        modelBuilder.Entity<BicycleType>()
            .Property(bt => bt.RentalPrice)
            .IsRequired();

        // Configure relationship between Bicycle and BicycleType
        modelBuilder.Entity<Bicycle>()
            .HasOne(b => b.BicycleType)  
            .WithMany(bt => bt.Bicycles)
            .HasForeignKey(b => b.TypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Configure relationship between Rental and Customer
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Customer)  
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CustomerId)  
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Configure relationship between Rental and Bicycle
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Bicycle)
            .WithMany(b => b.Rentals)
            .HasForeignKey(r => r.BicycleSerialNumber)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
