using BuildingManager.Repository.Constants;

namespace BuildingManager.Repository.Repositories.Person;

public static class PersonQueries
{
    public static string InsertPersonQuery()
    {
        return
            $"INSERT INTO {DemographicsDb.Schema}.{DemographicsDb.Tables.Person} " +
            $"(id, firstname, lastname, code, created_at)" +
            $" VALUES (@Id, @Firstname, @Lastname, @PersonCode, @CreatedAt)";
    }

    public static string SelectPersonQQuery()
    {
        return $"SELECT " +
               $"id AS @Id, " +
               $"firstname AS @Firstname, " +
               $"lastname AS @Lastname " +
               $"code AS @PersonCode " +
               $"created_at AS @CreatedAt " +
               $"FROM {DemographicsDb.Schema}.{DemographicsDb.Tables.Person}";
    }
}