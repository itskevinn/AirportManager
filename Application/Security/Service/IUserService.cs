using Application.Security.Http.Dto;
using Application.Security.Http.Request;
using Infrastructure.Common.Response;

namespace Application.Security.Service;

public interface IUserService : ITransientService
{
    public Task<Response<UserDto>> GetById(Guid id);
    public Task<Response<IEnumerable<UserDto>>> GetAll();
    public Task<Response<UserDto>> Save(UserRequest userRequest);
}