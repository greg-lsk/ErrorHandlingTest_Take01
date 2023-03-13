namespace Application.DataSource;

public interface IDataStateTracker
{
    public void EnableTracking();
    public void DisableTracking();
    public int ApplyChanges();
}