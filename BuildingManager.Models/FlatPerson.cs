namespace BuildingManager.Models;

public class FlatPerson
{
    public Flat Flat { get; set; }
    public Person Person { get; set; }
    public bool IsOwner { get; set; }
}