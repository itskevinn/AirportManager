using System.Data;
using Domain.Repository;
using Infrastructure.Persistence.Repository.Base;
using Microsoft.Data.SqlClient;

namespace Api.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection svc, string stringConnection)
    {
        if (stringConnection == null) throw new ArgumentNullException(nameof(stringConnection));
        svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        svc.AddTransient<IDbConnection>((_) => new SqlConnection(stringConnection));
        return svc;
    }
}