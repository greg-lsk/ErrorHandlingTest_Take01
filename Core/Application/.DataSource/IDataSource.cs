namespace Application.DataSource;

public interface IDataSource
{
    public IQueryable<TEntity> Get<TEntity>() where TEntity:class;

    public TEntity Add<TEntity>(TEntity entity) where TEntity:class;
}