using Application.Security.Http.Dto;
using Application.Security.Http.Request;
using Infrastructure.Security.Encrypt;
using Infrastructure.Security.Jwt;

namespace Application.Security.Service.Implementation;

public class AuthService : BaseService, IAuthService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<UserRole> _userRoleRepository;

    private readonly IMapper _mapper;
    private readonly IJwtUtils _jwtUtils;

    public AuthService(IGenericRepository<User> userRepository,
        IGenericRepository<UserRole> userRoleRepository,
        IGenericRepository<Role> roleRepository, IMapper mapper,
        IJwtUtils jwtUtils)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
        _jwtUtils = jwtUtils;
    }

    public async Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest)
    {
        var users = await _userRepository.GetAsync();
        var user = users.SingleOrDefault(x =>
            string.Equals(x.Username, authenticateRequest.Username, StringComparison.CurrentCultureIgnoreCase) &&
            x.Password == Hash.GetSha256(authenticateRequest.Password));
        if (user == null)
            return new Response<AuthenticateDto>(HttpStatusCode.Unauthorized, "Usuario o contraseña incorrectos",
                false);
        var userDto = _mapper.Map<UserDto>(user);
        var token = _jwtUtils.GenerateJwtToken(userDto);

        return new Response<AuthenticateDto>(HttpStatusCode.OK, "Bienvenido", true,
            new AuthenticateDto(userDto, token));
    }

    public async Task<UserDto> GetOnlyUserById(Guid id)
    {
        var user = _userRepository.Find(u => u.Id == id, false, "UserRoles");
        var userRoles =
            await _userRoleRepository.GetAsync(ur => ur.UserId == user.Id, null, false, "Role");
        var roles = new List<Role>();
        userRoles.ToList().ForEach(u => { roles.Add(u.Role); });
        user.Roles = roles;
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}