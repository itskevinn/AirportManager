using System.Net;
using Application.Airport.Service.Base;
using Application.Common.Response;
using Application.Security.Http.Dto;
using Application.Security.Http.Request;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Security.Jwt;

namespace Infrastructure.Security.Authentication.Service.Implementation;

public class AuthService : BaseService, IAuthService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtUtils _jwtUtils;

    public AuthService(IGenericRepository<User> userRepository, IMapper mapper,
        IJwtUtils jwtUtils)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtUtils = jwtUtils;
    }

    public async Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest)
    {
        var users = await _userRepository.GetAsync();
        var user = users.SingleOrDefault(x =>
            x.Username == authenticateRequest.Username && x.Password == authenticateRequest.Password);
        var userDto = _mapper.Map<UserDto>(user);
        if (user == null)
            return new Response<AuthenticateDto>(HttpStatusCode.Unauthorized, "Usuario o contraseña incorrectos",
                false);

        var token = _jwtUtils.GenerateJwtToken(userDto);

        return new Response<AuthenticateDto>(HttpStatusCode.OK, "Bienvenido", true,
            new AuthenticateDto(userDto, token));
    }

    public UserDto GetOnlyUserById(Guid id)
    {
        var user = _userRepository.FindAsync(id).Result;
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}