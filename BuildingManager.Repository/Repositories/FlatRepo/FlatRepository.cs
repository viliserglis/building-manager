using BuildingManager.Models;
using BuildingManager.Repository.Constants;
using BuildingManager.Repository.Infrastructure;
using Dapper;
using SqlKata;
using SqlKata.Compilers;

namespace BuildingManager.Repository.Repositories.FlatRepo;

public class FlatRepository : IFlatRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public FlatRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    private readonly string[] _columns =
    {
        $"id AS {nameof(Flat.Id)}",
        $"number AS {nameof(Flat.Number)}",
        $"house_number AS {nameof(Flat.HouseNumber)}",
        $"area AS {nameof(Flat.Area)}",
        $"people_count AS {nameof(Flat.PeopleCount)}"
    };

    public async Task Create(Models.Flat model)
    {
        var query = new Query(FlatDb.BuildingTables.Flat.WithSchema());
        var data = new Dictionary<string, object>()
        {
            ["id"] = Guid.NewGuid(),
            ["number"] = model.Number,
            ["house_number"] = model.HouseNumber,
            ["area"] = model.Area,
            ["people_count"] = model.PeopleCount
        };
        query.AsInsert(data);
        var sql = new PostgresCompiler().Compile(query).Sql;

        using var connection = _connectionFactory.GetConnection();
        await connection.ExecuteAsync(sql);
    }

    public async Task<IList<Models.Flat>> GetAllFlats()
    {
        var query = new Query(FlatDb.BuildingTables.Flat.WithSchema());

        query.Select(_columns);
        var sql = new PostgresCompiler().Compile(query).Sql;
        using var connection = _connectionFactory.GetConnection();
        var result = await connection.QueryAsync<Flat>(sql);
        return result.ToList();
    }

    public async Task<Flat> GetFlat(Guid id)
    {
        var query = new Query(FlatDb.BuildingTables.Flat.WithSchema());
        query.Select(_columns);
        query.Where("id", id);
        var sql = new PostgresCompiler().Compile(query).Sql;
        using var connection = _connectionFactory.GetConnection();
        var result = await connection.QueryFirstAsync<Flat>(sql);
        return result;
    }
}