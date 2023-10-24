using Security.Domain.Entity;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Context;
using Security.Infrastructure.Persistence.Repositories.Base;

namespace Security.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SecurityContext context) : base(context)
    {
    }

    public bool ExistsByUsername(string username)
    {
        return FindBy(u => u.Username == username) != null;
    }
}