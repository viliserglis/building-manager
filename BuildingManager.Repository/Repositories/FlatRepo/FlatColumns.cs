using BuildingManager.Models;

namespace BuildingManager.Repository.Repositories.FlatRepo;

internal static class FlatColumns
{
    private static readonly string[] _columns =
    {
        $"id AS {nameof(Flat.Id)}",
        $"number AS {nameof(Flat.Number)}",
        $"house_number AS {nameof(Flat.HouseNumber)}",
        $"area AS {nameof(Flat.Area)}",
        $"people_count AS {nameof(Flat.PeopleCount)}"
    };

    internal static string[] GetColumns()
    {
        return _columns;
    }
}