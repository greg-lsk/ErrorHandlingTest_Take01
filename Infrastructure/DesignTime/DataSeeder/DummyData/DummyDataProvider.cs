using Domain.Entities;
using DataSeeder.DummyData.Producers;


namespace DataSeeder.DummyData;

internal class DummyDataProvider
{
    internal List<CarManufacturer> Manufacturers { get; init; }
    internal List<CarModel> Models { get; init; }


    internal DummyDataProvider()
    {
        Manufacturers = new();
        Models = new();
        new ManufacturerModelsSeeder().Seed(Manufacturers, Models);
    }
}