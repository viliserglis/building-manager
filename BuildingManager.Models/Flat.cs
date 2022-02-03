namespace BuildingManager.Models;

public class Flat
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public decimal Area { get; set; }
    public string HouseNumber { get; set; }
    public int PeopleCount { get; set; }
}