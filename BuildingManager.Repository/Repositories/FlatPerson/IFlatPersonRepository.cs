namespace BuildingManager.Repository.Repositories.FlatPerson;

public interface IFlatPersonRepository
{
    Task Create(Models.FlatPerson model);
}