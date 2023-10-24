using AirportGateway.App.Core.Interface;
using AirportGateway.App.Security.Http.Dto;

namespace AirportGateway.App.Base;

public interface IBaseService 
{
    protected UserDto GetCurrentUser();
}