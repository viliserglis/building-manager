using BuildingManager.Models;

namespace BuildingManager.Repository.Repositories.FlatRepo;

public interface IFlatRepository
{
    Task Create(Flat model);
    Task<IList<Flat>> GetAllFlats();
    Task<Flat> GetFlat(Guid id);
}