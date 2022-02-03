using BuildingManager.Repository.Constants;
using BuildingManager.Repository.Infrastructure;
using Dapper;
using SqlKata;
using SqlKata.Compilers;

namespace BuildingManager.Repository.Repositories.Flat;

public class FlatRepository : IFlatRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public FlatRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

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
}