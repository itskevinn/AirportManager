using System.Data;
using System.Data.SqlClient;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Repositories;

namespace Security.Api.Utils.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection svc, IConfiguration config)
    {
        svc.AddTransient(typeof(IMenuItemRepository), typeof(MenuItemRepository));
        svc.AddTransient(typeof(IMenuItemRoleRepository), typeof(MenuItemRoleRepository));
        svc.AddTransient(typeof(IRoleRepository), typeof(RoleRepository));
        svc.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        svc.AddTransient(typeof(IUserRoleRepository), typeof(UserRoleRepository));
        svc.AddTransient<IDbConnection>(_ => new SqlConnection(config.GetConnectionString("local")));

        return svc;
    }
}