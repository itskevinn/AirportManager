using Application.Security.Http.Dto;
using Application.Security.Http.Request;

namespace Application.Security.Service.Implementation;

public class UserService : BaseService, IUserService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IGenericRepository<User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<Response<UserDto>> Save(UserRequest userRequest)
    {
        try
        {
            var user = _mapper.Map<User>(userRequest);
            user = await _userRepository.CreateAsync(user);
            var userDto = _mapper.Map<UserDto>(user);
            return new Response<UserDto>(HttpStatusCode.OK, "Usuario registrado", true, userDto);
        }
        catch (Exception e)
        {
            return new Response<UserDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, null!, e);
        }
    }

    public async Task<Response<IEnumerable<UserDto>>> GetAll()
    {
        try
        {
            var users = await _userRepository.GetAsync();
            var userDtoList = _mapper.Map<IEnumerable<UserDto>>(users);
            return new Response<IEnumerable<UserDto>>
                (HttpStatusCode.OK, "Usuarios encontrados", true, userDtoList);
        }
        catch (Exception e)
        {
            return new Response<IEnumerable<UserDto>>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<UserDto>> GetById(Guid id)
    {
        try
        {
            var user = await _userRepository.FindAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return new Response<UserDto>
                (HttpStatusCode.OK, "Usuario encontrado", true, userDto);
        }
        catch (Exception e)
        {
            return new Response<UserDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }
    
}

