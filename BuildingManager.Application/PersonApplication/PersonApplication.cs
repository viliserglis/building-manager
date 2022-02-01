using BuildingManager.Repository.Repositories.Person;

namespace BuildingManager.Application.PersonApplication;

public class PersonApplication
{
    private readonly IPersonRepository _repository;

    public PersonApplication(IPersonRepository repository)
    {
        _repository = repository;
    }
    
    
}