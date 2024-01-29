using core_domain.Data;
using core_domain.Data.Actors;
using core_domain.Data.Entities;
using core_domain.Data.Link;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace core_infrastructure.Context;

public class DatabaseEntityContext : DbContext
{
    //Actors
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Operator> Operators { get; set; }

    //Entities
    public DbSet<Company> Companies { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Revision> Revisions { get; set; }
    
    //Link
    public DbSet<CustomerProjects> CustomerProjects { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DatabaseEntityContext(DbContextOptions<DatabaseEntityContext> contextOptions) : base (contextOptions) {}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //Many to Many Relations
        modelBuilder.Entity<CustomerProjects>().HasKey(cp => new
        {
            cp.ProjectId, cp.CustomerId
        });

        modelBuilder.Entity<CustomerProjects>()
            .HasOne<Customer>(cp => cp.Customer)
            .WithMany(cu => cu.CustomerProjects)
            .HasForeignKey(cu => cu.CustomerId);
        
        modelBuilder.Entity<CustomerProjects>()
            .HasOne<Project>(cp => cp.Project)
            .WithMany(cu => cu.CustomerProjects)
            .HasForeignKey(cu => cu.ProjectId);
        
        //One to Many Relations
        modelBuilder.Entity<Customer>()
            .HasOne<Company>(cu => cu.Company)
            .WithMany(co => co.Customers)
            .HasForeignKey(cu => cu.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Revision>()
            .HasOne<Project>(re => re.Project)
            .WithMany(pr => pr.Revisions)
            .HasForeignKey(re => re.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Operation>()
            .HasOne<Revision>(op => op.Revision)
            .WithMany(re => re.Operations)
            .HasForeignKey(op => op.RevisionId);

        modelBuilder.Entity<Order>()
            .HasOne<Customer>(or => or.Customer)
            .WithMany(cu => cu.Orders)
            .HasForeignKey(or => or.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Order>()
            .HasOne<Revision>(or => or.Revision)
            .WithMany(re => re.Orders)
            .HasForeignKey(or => or.RevisionId)
            .OnDelete(DeleteBehavior.SetNull);
        
        base.OnModelCreating(modelBuilder);
    }

    override public int SaveChanges()
    {
        IEnumerable<EntityEntry> entries = ChangeTracker.Entries().Where(
            entry => entry is { Entity: DatabaseEntity, State: EntityState.Added or EntityState.Modified }
        );
        
        foreach (EntityEntry entityEntry in entries)
        {
            DatabaseEntity entity = (DatabaseEntity) entityEntry.Entity;
            entity.DateUpdated = DateTime.Now;
            entity.DateCreated = entityEntry.State == EntityState.Added ? DateTime.Now : entity.DateCreated;
        }
        
        return base.SaveChanges();
    }
    
    override public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        IEnumerable<EntityEntry> entries = ChangeTracker.Entries().Where(
            entry => entry is { Entity: DatabaseEntity, State: EntityState.Added or EntityState.Modified }
        );
        
        foreach (EntityEntry entityEntry in entries)
        {
            DatabaseEntity entity = (DatabaseEntity) entityEntry.Entity;
            entity.DateUpdated = DateTime.Now;
            entity.DateCreated = entityEntry.State == EntityState.Added ? DateTime.Now : entity.DateCreated;
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }

}
