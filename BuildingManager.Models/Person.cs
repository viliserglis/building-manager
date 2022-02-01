namespace BuildingManager.Models;

public class Person
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string PersonCode { get; set; }
    public DateTime CreatedAt { get; set; }
}