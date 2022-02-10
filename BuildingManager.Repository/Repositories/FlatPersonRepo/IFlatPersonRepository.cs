using BuildingManager.Models;
namespace BuildingManager.Repository.Repositories.FlatPersonRepo;

public interface IFlatPersonRepository
{
    Task Create(Models.FlatPerson model);
    Task<IList<Person>> GetFlatPersons(Guid flatId);
    Task<IList<Flat>> GetPersonFlats(Guid personId);
}