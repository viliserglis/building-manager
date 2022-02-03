using BuildingManager.Repository.Constants;
using BuildingManager.Repository.Infrastructure;
using Dapper;
using SqlKata;
using SqlKata.Compilers;

namespace BuildingManager.Repository.Repositories.FlatPerson;

public class FlatPersonRepository : IFlatPersonRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public FlatPersonRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task Create(Models.FlatPerson model)
    {
        var query = new Query(FlatDb.BuildingTables.PersonFlat.WithSchema());
        var data = new Dictionary<string, object>()
        {
            ["person_id"] = model.Person.Id,
            ["flat_id"] = model.Flat.Id,
            ["is_owner"] = model.IsOwner
        };

        query.AsInsert(data);
        var sql = new PostgresCompiler().Compile(query).Sql;
        using var connection = _connectionFactory.GetConnection();
        await connection.ExecuteAsync(sql);
    }
}