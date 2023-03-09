using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ORM.Persistence.ModelConfiguration;

internal class CarManufacturerConfigurator : IEntityTypeConfiguration<CarManufacturer>
{
    public void Configure(EntityTypeBuilder<CarManufacturer> builder)
    {
        builder
            .Property(manufacturer => manufacturer.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasIndex(manufacturer => manufacturer.Name)
            .IsUnique();

        builder
            .HasMany(manufacturer => manufacturer.Models)
            .WithOne(model => model.Manufacturer);
    }

}