using Entities = Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Queries.DataAccess;

public interface IDataAccessor
{
    public DbSet<Entities::User> Users { get; set; }
    public DbSet<Entities::CarManufacturer> Manufacturers { get; set; }
    public DbSet<Entities::CarModel> Models { get; set; }
    public DbSet<Entities::Car> Cars { get; set; }
    public DbSet<Entities::CarOwnership> CarOwnerships { get; set; }


    public int SaveChanges();
}