using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ORM.Persistence.ModelConfiguration;

internal class CarOwnershipConfigurator : IEntityTypeConfiguration<CarOwnership>
{
    public void Configure(EntityTypeBuilder<CarOwnership> builder)
    {
        builder
            .HasKey(ownership => new { ownership.OwnerId, ownership.CarId });

        builder
            .HasOne(ownership => ownership.Owner)
            .WithMany(owner => owner.Cars)
            .HasForeignKey(ownership => ownership.OwnerId);

        builder
            .HasOne(ownership => ownership.Car)
            .WithMany(car => car.Owners)
            .HasForeignKey(ownership => ownership.CarId);
    }
}
