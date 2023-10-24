using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Entity;

namespace Security.Infrastructure.Persistence.Mapping;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(t => t.RoleName).IsRequired().HasMaxLength(20);
        builder.Property(p => p.LastModifiedBy).IsRequired(false);
    }
}