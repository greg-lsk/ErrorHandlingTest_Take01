using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ORM.Persistence.ModelConfiguration;

internal class UserConfigurator : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasIndex(user => user.Email)
            .IsUnique();

        builder
            .Property(user => user.Password)
            .IsRequired()
            .HasMaxLength(20);
    }
}
