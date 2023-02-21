using Domain.ValueTypes;


namespace DataSeeder.DummyData.Producers;

internal class PeriodChainProducer
{
    private const string _dateFormat = "yyyy-MM-dd";

    internal IEnumerable<Period> GenerateContinuousPeriods()
    {
        var periods = new List<Period>();

        var randomizer = new Random();
        int yearSpan = randomizer.Next(10, 15);
        int periodLength = randomizer.Next(4, 6);

        var start = DateTime.Now.AddYears(-yearSpan);
        var end = start.AddYears(periodLength);

        var segments = yearSpan / periodLength;

        for (int i = 0; i < segments; ++i)
        {
            if (i == segments - 1)
            {
                periods.Add(
                    new(start.ToString(_dateFormat)));
                return periods;
            }

            periods.Add(
                new(start.ToString(_dateFormat), end.ToString(_dateFormat)));

            start = end;
            end = start.AddYears(periodLength);
        }

        return periods;
    }

}