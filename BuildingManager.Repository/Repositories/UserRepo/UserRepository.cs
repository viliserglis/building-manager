using BuildingManager.Repository.Infrastructure;

namespace BuildingManager.Repository.Repositories.UserRepo;

public class UserRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public UserRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task CreateUser(UserModel)
}