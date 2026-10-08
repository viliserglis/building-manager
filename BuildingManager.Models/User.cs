namespace BuildingManager.Models;

public class User
{
    public Guid Id { get; set; }
    public Person Person { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}