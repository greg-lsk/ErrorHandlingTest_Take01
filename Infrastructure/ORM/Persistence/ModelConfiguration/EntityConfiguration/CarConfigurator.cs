using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ORM.Persistence.ModelConfiguration;

internal class CarConfigurator : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        /*        builder
                    .Property(car => car.Model)
                    .IsRequired();*/
    }
}