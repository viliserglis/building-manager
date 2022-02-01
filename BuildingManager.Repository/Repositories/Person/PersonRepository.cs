using BuildingManager.Repository.Infrastructure;
using Dapper;

namespace BuildingManager.Repository.Repositories.Person;

public class PersonRepository : IPersonRepository
{
    private readonly ConnectionFactory _connectionFactory;


    public PersonRepository(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> Insert(Models.Person model)
    {
        using var connection = _connectionFactory.GetConnection();
        model.Id = Guid.NewGuid();
        var query = PersonQueries.InsertPersonQuery();
        await connection.ExecuteAsync(query, model);
        return model.Id;
    }

    public async Task<Models.Person> GetPerson(Guid id)
    {
        using var connection = _connectionFactory.GetConnection();
        var query = PersonQueries.SelectPersonQQuery();
        var parameters = new DynamicParameters();
        parameters.Add("id", id);
        var result = await connection.QuerySingleAsync<Models.Person>(query, parameters);
        return result;
    }
}