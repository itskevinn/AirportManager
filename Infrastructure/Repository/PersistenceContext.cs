using Domain.Constants.Enum;
using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repository;

public class PersistenceContext : DbContext
{
    private readonly IConfiguration _config;

    public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    public async Task CommitAsync()
    {
        await SaveChangesAsync().ConfigureAwait(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));
        EntitiesConfig(modelBuilder);
        SetDefaultValues(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void EntitiesConfig(ModelBuilder modelBuilder)
    {
        FlightEntityConfig(modelBuilder);
        AirlineEntityConfig(modelBuilder);
        CityEntityConfig(modelBuilder);
        UserEntityConfig(modelBuilder);
        RoleEntityConfig(modelBuilder);
        UserRoleInterceptorConfig(modelBuilder);
        MenuItemRoleInterceptorConfig(modelBuilder);
    }


    private static void MenuItemRoleInterceptorConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItemRole>(mi =>
        {
            mi.HasKey(mi => new { mi.RoleId, mi.MenuItemId });
            mi.HasOne(mi => mi.Role)
                .WithMany(r => r.RoleMenuItems)
                .HasForeignKey(mi => mi.RoleId);
            mi.HasOne(mi => mi.MenuItem)
                .WithMany(r => r.MenuItemRoles)
                .HasForeignKey(mi => mi.MenuItemId);
            mi.Property("CreatedBy").IsRequired(false);
        });
    }

    private static void RoleEntityConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity => { entity.HasKey(r => r.Id); });
    }

    private static void UserEntityConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity => { entity.HasKey(u => u.Id); });
    }

    private static void UserRoleInterceptorConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.RoleId, ur.UserId });
        modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
        modelBuilder.Entity<UserRole>(ur => ur.Property(r => r.CreatedBy).IsRequired(false));
        modelBuilder.Entity<UserRole>().HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);
    }

    private static void CityEntityConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity => { entity.HasKey(c => c.Id); });
    }

    private static void AirlineEntityConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name).IsRequired();
        });
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

    private static void FlightEntityConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(
            entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.FlightStatus)
                    .HasConversion(
                        v => v.ToString(),
                        v => (FlightStatus)Enum.Parse(typeof(FlightStatus), v))
                    .IsRequired();
                entity.Property(f => f.CheckInTime).IsRequired();
                entity.Property(f => f.CheckOutTime).IsRequired();
                entity.Property(f => f.CheckOutDate).IsRequired();
                entity.HasOne(f => f.DepartureCity).WithMany().HasForeignKey(f => f.DepartureCityId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(f => f.DestinyCity).WithMany().HasForeignKey(f => f.DestinyCityId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
    }
}