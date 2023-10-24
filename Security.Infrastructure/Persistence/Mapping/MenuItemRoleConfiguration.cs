using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Entity;

namespace Security.Infrastructure.Persistence.Mapping;

public class MenuItemRoleConfiguration : IEntityTypeConfiguration<MenuItemRole>
{
    public void Configure(EntityTypeBuilder<MenuItemRole> builder)
    {
        builder.HasKey(mr => new { mr.RoleId, mr.MenuItemId });
        builder.HasOne(mr => mr.Role)
            .WithMany(r => r.RoleMenuItems)
            .HasForeignKey(mr => mr.RoleId);
        builder.HasOne(mr => mr.MenuItem)
            .WithMany(r => r.MenuItemRoles)
            .HasForeignKey(mr => mr.MenuItemId);
        builder.Property("CreatedBy").IsRequired(false);
        builder.Property(p => p.LastModifiedBy).IsRequired(false);
    }
}