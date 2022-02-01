using System.Data;
using BuildingManager.Repository.IoC;
using Microsoft.Extensions.Options;
using Npgsql;

namespace BuildingManager.Repository.Infrastructure;

public class ConnectionFactory : IConnectionFactory
{
    private readonly IOptions<RepositoryConfiguration> _configuration;


    public ConnectionFactory(IOptions<RepositoryConfiguration> configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_configuration.Value.ConnectionString);
    }
}