using BuildingManager.Models;
using BuildingManager.Repository.Repositories.FlatRepo;

namespace BuildingManager.Application.FlatApplication;

public class FlatApplication : IFlatApplication
{
    private readonly IFlatRepository _repository;

    public FlatApplication(IFlatRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(Flat model)
    {
        await _repository.Create(model);
    }

    public Task<IList<Flat>> GetAllFlats()
    {
        throw new NotImplementedException();
    }

    public Task<Flat> GetFlat(Guid id)
    {
        throw new NotImplementedException();
    }
}