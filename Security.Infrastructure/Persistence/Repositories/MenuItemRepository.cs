
using Security.Domain.Entity;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Context;
using Security.Infrastructure.Persistence.Repositories.Base;

namespace Security.Infrastructure.Persistence.Repositories;

public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
{
    public MenuItemRepository(SecurityContext securityContext) : base(securityContext)
    {
    }
}