using BuildingManager.Models;
namespace BuildingManager.Repository.Repositories.FlatPersonRepo;

public interface IFlatPersonRepository
{
    Task Create(Models.FlatPerson model);
    Task<Models.FlatPerson> GetFlatPersons(Guid flatId);
    Task<Models.FlatPerson> GetPersonFlats(Guid personId);
}