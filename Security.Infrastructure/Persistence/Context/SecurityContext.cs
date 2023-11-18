using Microsoft.EntityFrameworkCore;
using Security.Domain.Entity.Base;
using Security.Infrastructure.Persistence.Configuration;
using Security.Infrastructure.Persistence.Seeding;

namespace Security.Infrastructure.Persistence.Context;

public class SecurityContext : DbContext
{
    public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
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
        Seeder.GenerateSeeds(modelBuilder);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var t = entityType.ClrType;
            if (!typeof(DomainEntity).IsAssignableFrom(t)) continue;
            modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValue(DateTime.Now);
            modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn")
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity(entityType.Name).Property<string>("LastModifiedBy").IsRequired(false);
        }
    }
}