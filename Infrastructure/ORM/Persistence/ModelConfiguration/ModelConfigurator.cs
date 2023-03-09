using Microsoft.EntityFrameworkCore;


namespace ORM.Persistence.ModelConfiguration;

internal class ModelConfigurator
{
    public ModelConfigurator(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new UserConfigurator())
            .ApplyConfiguration(new CarManufacturerConfigurator())
            .ApplyConfiguration(new CarModelConfigurator())
            .ApplyConfiguration(new CarConfigurator())
            .ApplyConfiguration(new CarOwnershipConfigurator());
    }
}