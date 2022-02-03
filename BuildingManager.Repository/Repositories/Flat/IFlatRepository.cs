namespace BuildingManager.Repository.Repositories.Flat;

public interface IFlatRepository
{
    Task Create(Models.Flat model);
}