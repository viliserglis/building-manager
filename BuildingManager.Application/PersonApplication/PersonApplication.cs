using BuildingManager.Repository.Repositories.Person;
using BuildingManager.Repository.Repositories.PersonRepo;

namespace BuildingManager.Application.PersonApplication;

public class PersonApplication
{
    private readonly IPersonRepository _repository;

    public PersonApplication(IPersonRepository repository)
    {
        _repository = repository;
    }
    
    
}