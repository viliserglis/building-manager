using BuildingManager.Repository.Repositories.PersonRepo;

namespace BuildingManager.Application.PersonApplication;

public class PersonApplication : IPersonApplication
{
    private readonly IPersonRepository _repository;

    public PersonApplication(IPersonRepository repository)
    {
        _repository = repository;
    }
    
    
}