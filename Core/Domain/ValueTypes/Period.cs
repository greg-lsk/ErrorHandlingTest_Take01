namespace Domain.ValueTypes;

public class Period
{
    public DateTime From { get; private set; } 
    public DateTime? To { get; private set; }

    public bool IsActive => To == null;


   public Period()
    {
        From = DateTime.MinValue;
        To = DateTime.MaxValue;
    }

    public Period(string fromDate)
    {
        From = DateTime.Parse(fromDate);
        To = null;
    }

    public Period(string fromDate, string toDate)
    {
        From = DateTime.Parse(fromDate);
        To = DateTime.Parse(toDate);
    }


    public override string ToString()
    {
        switch (IsActive)
        {
            case true:
                return $"{From.Year}-Ongoing";
            case false:
                return $"{From.Year}-{To.Value.Year}";
        }
    }

}