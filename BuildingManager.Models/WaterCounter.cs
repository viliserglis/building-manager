namespace BuildingManager.Models;

public class WaterCounter
{
    public Guid Id { get; set; }
    public DateTime Setup { get; set; }
    public string Number { get; set; }
    public string AuthorisedPerson { get; set; }
}