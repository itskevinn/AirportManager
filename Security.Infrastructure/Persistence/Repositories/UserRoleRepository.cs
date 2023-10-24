using Security.Domain.Entity;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Context;
using Security.Infrastructure.Persistence.Repositories.Base;

namespace Security.Infrastructure.Persistence.Repositories;

public class UserRoleRepository: GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(SecurityContext context) : base(context)
    {
    }
}