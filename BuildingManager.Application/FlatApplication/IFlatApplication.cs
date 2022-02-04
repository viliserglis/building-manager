using BuildingManager.Models;

namespace BuildingManager.Application.FlatApplication;

public interface IFlatApplication
{
    Task Create(Flat model);
    Task<IList<Flat>> GetAllFlats();
    Task<Flat> GetFlat(Guid id);
}