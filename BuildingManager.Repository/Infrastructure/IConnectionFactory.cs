using System.Data;

namespace BuildingManager.Repository.Infrastructure;

public interface IConnectionFactory
{
    IDbConnection GetConnection();
}