using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Entity;

namespace Security.Infrastructure.Persistence.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(30);
        builder.Property(p => p.Username).HasMaxLength(15);
        builder.Property(p => p.Email).HasMaxLength(50).IsRequired(false);
        builder.Property(p => p.LastModifiedBy).IsRequired(false);
    }
}