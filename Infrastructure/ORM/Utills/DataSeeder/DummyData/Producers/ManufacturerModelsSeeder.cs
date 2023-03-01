using Domain.Entities;


namespace DataSeeder.DummyData.Producers;

internal class ManufacturerModelsSeeder
{

    private readonly Dictionary<string, List<string>> _manufacturerModels;
    private readonly PeriodChainProducer _periodsProvider;


    internal ManufacturerModelsSeeder()
    {
        _periodsProvider = new();
        _manufacturerModels = new Dictionary<string, List<string>>
        {
            ["Opel"]       = new() {"Astra", "Corsa"},
            ["Ford"]       = new() {"Focus", "Fiesta"},
            ["Peugeot"]    = new() {"308", "208"},
            ["Volkswagen"] = new() {"Golf", "Polo"}
        };
    }


    internal void Seed(ICollection<CarManufacturer> manufacturers,
                       ICollection<CarModel> modelsOfManufacturer)
    {
        foreach (var manufacturerName in _manufacturerModels.Keys)
        {
            var manufacturer = new CarManufacturer(manufacturerName, new List<CarModel>());
            manufacturers.Add(manufacturer);

            SeedModels(
                modelsOfManufacturer,
                _manufacturerModels[manufacturerName],
                manufacturer);
        }
    }

    private void SeedModels(ICollection<CarModel> models,
                            ICollection<string> names,
                            CarManufacturer ofManufacturer)
    {
        foreach (var modelName in names)
        {
            var periods = _periodsProvider.GenerateContinuousPeriods();

            foreach(var period in periods)
                models.Add(new(modelName, ofManufacturer, period));
        }
    }

}