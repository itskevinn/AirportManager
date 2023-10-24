using Security.Domain.Entity;

namespace Security.Domain.Ports;

public interface IUserRepository: IGenericRepository<User>
{
    bool ExistsByUsername(string username);
}