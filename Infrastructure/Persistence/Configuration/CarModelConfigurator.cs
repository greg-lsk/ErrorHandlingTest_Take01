using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configuration;

internal class CarModelConfigurator : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder
            .Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .OwnsOne(model => model.ProductionPeriod);

        builder
            .HasMany(model => model.OfCars)
            .WithOne(car => car.Model)
            .OnDelete(DeleteBehavior.SetNull);
    }
}