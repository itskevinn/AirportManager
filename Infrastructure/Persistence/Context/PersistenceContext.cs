using Domain.Entities.Base;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class PersistenceContext : DbContext
{
    public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SetDefaultValues(modelBuilder);
        EntitiesConfigurator.Configure(modelBuilder);
    }

    private static void SetDefaultValues(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var t = entityType.ClrType;
            if (!typeof(DomainEntity).IsAssignableFrom(t)) continue;
            modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn")
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity(entityType.Name).Property<string>("UpdatedBy").IsRequired(false);
        }
    }
}