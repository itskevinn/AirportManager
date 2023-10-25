using System.Net;
using AutoMapper;
using Security.Application.Base;
using Security.Application.Http.Dto;
using Security.Application.Http.Request;
using Security.Domain.Entity;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Exceptions;
using Security.Infrastructure.Security.Encrypt;
using Security.Infrastructure.Security.Jwt;

namespace Security.Application.Service.Implementation;

public class AuthService : BaseService<User>, IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtUtils _jwtUtils;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthService(IUserService userService, IUserRepository userRepository, IJwtUtils jwtUtils,
        IMapper mapper) :
        base(mapper)
    {
        _userRepository = userRepository ??
                          throw new RepoUnavailableException($"{nameof(userRepository)}");

        _userService = userService;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public async Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest)
    {
        var users = await _userRepository.GetAsync();

        var user = users.SingleOrDefault(x =>
            string.Equals(x.Username.ToLower(), authenticateRequest.Username.ToLower()) &&
            x.Password == Hash.GetSha256(authenticateRequest.Password));
        if (user == null)
            return new Response<AuthenticateDto>(HttpStatusCode.Unauthorized, "Usuario o contraseña incorrectos",
                false);
        var userDto = await _userService.GetById(user.Id);
        var token = _jwtUtils.GenerateJwtToken(_mapper.Map<Infrastructure.Security.Models.UserDto>(userDto.Data));
        return new Response<AuthenticateDto>(HttpStatusCode.OK, "Bienvenido", true,
            new AuthenticateDto(userDto.Data, token));
    }

    public Guid GetUserIdFromToken(string token)
    {
        return _jwtUtils.ValidateJwtToken(token);
    }
}