using BuildingManager.Models;
using BuildingManager.Repository.Constants;
using BuildingManager.Repository.Infrastructure;
using BuildingManager.Repository.Repositories.FlatRepo;
using BuildingManager.Repository.Repositories.PersonRepo;
using Dapper;
using SqlKata;
using SqlKata.Compilers;

namespace BuildingManager.Repository.Repositories.FlatPersonRepo;

public class FlatPersonRepository : IFlatPersonRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public FlatPersonRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task Create(FlatPerson model)
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

    public async Task<IList<Person>> GetFlatPersons(Guid flatId)
    {
        var query = new Query(DemographicsDb.Tables.Person.WithSchema());
        query.Select(PersonQueries.SelectPersonQQuery());
        query.Join(FlatDb.BuildingTables.PersonFlat.WithSchema(), "id", "person_id");
        query.Where($"{FlatDb.BuildingTables.PersonFlat.WithSchema()}.flat_id", flatId);
        var sql = new PostgresCompiler().Compile(query).Sql;
        using var connection = _connectionFactory.GetConnection();
        var result = await connection.QueryAsync<Person>(sql);
        return result.ToList();
    }

    public async Task<IList<Flat>> GetPersonFlats(Guid personId)
    {
        var query = new Query(FlatDb.BuildingTables.Flat.WithSchema());
        query.Select(FlatColumns.GetColumns());
        query.Join(FlatDb.BuildingTables.PersonFlat.WithSchema(), "id", "flat_id");
        query.Where($"{FlatDb.BuildingTables.PersonFlat.WithSchema()}.person_id", personId);
        var sql = new PostgresCompiler().Compile(query).Sql;
        using var connection = _connectionFactory.GetConnection();
        var result = await connection.QueryAsync<Flat>(sql);
        return result.ToList();
    }
}