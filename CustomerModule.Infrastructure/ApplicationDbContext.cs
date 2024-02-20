using CustomerModule.Domain;
using CustomerModule.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerModule.Infrastructure;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<CustomerInformation> CustomerInformations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Customer>()
            .ToTable("customer")
            .Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<CustomerInformation>()
            .ToTable("customer_informations")
            .Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");;
        // .HasOne(ci => ci.Customer)
        // .WithMany(c => c.CustomerInfos)
        // .HasForeignKey(ci => ci.Customer_Id);
    }
}
