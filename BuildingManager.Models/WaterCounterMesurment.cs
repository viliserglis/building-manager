namespace BuildingManager.Models;

public class WaterCounterMesurment
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Measurement { get; set; }
}