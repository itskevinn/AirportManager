using Security.Domain.Entity;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Context;
using Security.Infrastructure.Persistence.Repositories.Base;

namespace Security.Infrastructure.Persistence.Repositories;

public class MenuItemRoleRepository : GenericRepository<MenuItemRole>, IMenuItemRoleRepository
{
    public MenuItemRoleRepository(SecurityContext context) : base(context)
    {
    }
}