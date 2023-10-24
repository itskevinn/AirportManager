using System.Data;
using Domain.Repository;
using Infrastructure.Persistence.Repository.Base;
using Microsoft.Data.SqlClient;

namespace Api.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection svc, IConfiguration config)
    {
        svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        svc.AddTransient<IDbConnection>((_) => new SqlConnection(config.GetConnectionString("local")));
        return svc;
    }
}