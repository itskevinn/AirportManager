using Application.Http.Dto;
using Domain.Entities.Base;
using Microsoft.AspNetCore.Http;

namespace Application.Base;

public class BaseService<TEntity> where TEntity : DomainEntity
{
    protected const string AnErrorHappenedMessage = "Ocurrió un error";
    private readonly IHttpContextAccessor? _contextAccessor;

    protected BaseService()
    {
    }

    protected BaseService(
        IHttpContextAccessor context)
    {
        _contextAccessor = context;
    }

    /// <summary>
    /// Use this method to set the user that is authenticated to the audit attributes of the specified entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="updating">Determines if the entity is being updated in order to set the LastModifiedBy attribute as well <seealso cref="AuditableEntity{TKey}"/>></param>
    protected void SetAuditValuesToEntity(TEntity entity, bool updating = false)
    {
        var value = (UserDto)_contextAccessor?.HttpContext?.Items["User"]!;
        entity.GetType().GetProperty("Status")?.SetValue(entity, true);
        entity.GetType().GetProperty("GeneratedBy")?.SetValue(entity, value.Username, null);
        switch (updating)
        {
            case false:
                entity.GetType().GetProperty("CreatedOn")?.SetValue(entity, DateTime.Now, null);
                entity.GetType().GetProperty("CreatedBy")?.SetValue(entity, value.Username, null);
                break;
            case true:
                entity.GetType().GetProperty("LastModifiedBy")?.SetValue(entity, value.Username, null);
                break;
        }
    }
}