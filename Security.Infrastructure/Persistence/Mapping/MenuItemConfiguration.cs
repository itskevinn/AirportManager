using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Entity;

namespace Security.Infrastructure.Persistence.Mapping;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasKey(mi => mi.Id);
        builder.Property(mi => mi.Icon).HasMaxLength(30).IsRequired();
        builder.Property(mi => mi.RouterLink).HasMaxLength(255).IsRequired();
        builder.Property(mi => mi.Order).IsRequired();
        builder.Property(mi => mi.Label).HasMaxLength(30).IsRequired();
        builder.Property(mi => mi.LastModifiedBy).IsRequired(false);
    }
}