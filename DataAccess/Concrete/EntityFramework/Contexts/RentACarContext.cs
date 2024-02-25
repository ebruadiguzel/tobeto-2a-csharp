using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class RentACarContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Car> Cars { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomer { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomer { get; set; }
    
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public RentACarContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Brand>().HasKey(i => i.Id).HasName("Markalar"); // EF Core Naming Convention BrandId
        modelBuilder.Entity<Brand>(i =>
        {
            //i.ToTable("Markalar");
            i.HasKey(i => i.Id);
            i.Property(i => i.Premium).HasDefaultValue(true);
        });
        base.OnModelCreating(modelBuilder); // normalde yaptığı işlemleri sürdürür
    }
}