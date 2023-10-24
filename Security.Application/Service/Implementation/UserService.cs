using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Security.Application.Base;
using Security.Application.Http.Dto;
using Security.Application.Http.Request;
using Security.Domain.Entity;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Exceptions;
using Security.Infrastructure.Security.Encrypt;

namespace Security.Application.Service.Implementation;

public class UserService : BaseService<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IMenuItemRoleRepository _menuItemRoleRepository;


    public UserService(IMapper mapper,
        IHttpContextAccessor accessor,
        IUserRoleRepository userRoleRepository, IMenuItemRoleRepository menuItemRoleRepository,
        IUserRepository userRepository, IMenuItemRepository menuItemRepository) : base(accessor, mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException($"{nameof(mapper)}");
        _userRoleRepository = userRoleRepository ??
                              throw new RepoUnavailableException($"{nameof(userRoleRepository)}");
        _menuItemRoleRepository = menuItemRoleRepository ??
                                  throw new RepoUnavailableException($"{nameof(menuItemRoleRepository)}");
        _userRepository = userRepository ??
                          throw new RepoUnavailableException($"{nameof(userRepository)}");
        _menuItemRepository = menuItemRepository ??
                              throw new RepoUnavailableException($"{nameof(menuItemRepository)}");
    }

    public async Task<Response<UserDto>> Save(UserRequest userRequest)
    {
        try
        {
            var user = _mapper.Map<User>(userRequest);
            user.Password = Hash.GetSha256(user.Password);
            SetCurrentUserToEntity(user);
            user = await _userRepository.CreateAsync(user);
            await _userRoleRepository.CreateAsync(new UserRole(user.Id, userRequest.RoleId));
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
            var users = await _userRepository.GetAsync(null, null, false, "UserRoles,UserRoles.Role");
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
            var user = await _userRepository.FindByAsync(u => u.Id == id, false,
                "UserRoles,UserRoles.Role,UserRoles.Role.RoleMenuItems,UserRoles.Role.RoleMenuItems.MenuItem");
            if (user == null) return null!;
            var userDto = await SetUserRoles(user);
            var authorities = new List<MenuItem>();
            await SetRoleAuthorities(userDto, authorities);
            return new Response<UserDto>
                (HttpStatusCode.OK, "Usuario encontrado", true, userDto);
        }
        catch (Exception e)
        {
            return new Response<UserDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    private async Task<UserDto> SetUserRoles(User user)
    {
        var userRoles =
            await _userRoleRepository.GetAsync(ur => ur.UserId == user.Id, null, false, "Role");
        var roles = new List<Role>();
        userRoles.ToList().ForEach(u => { roles.Add(u.Role); });
        user.Roles = roles;
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    private async Task SetRoleAuthorities(UserDto userDto, List<MenuItem> authorities)
    {
        foreach (var userDtoRole in userDto.Roles)
        {
            var roleMenuItems = await
                _menuItemRoleRepository.GetAsync(m => m.RoleId == userDtoRole.Id);
            await roleMenuItems.ForEachAsync(r =>
            {
                var auths = _menuItemRepository.GetAsync(m => m.Id == r.MenuItemId).Result.OrderBy(m => m.Order) ??
                            throw new InvalidOperationException();
                authorities.AddRange(auths);
            });
            var authoritiesDto = _mapper.Map<IEnumerable<MenuItemDto>>(authorities);
            userDtoRole.Authorities = authoritiesDto.OrderBy(a => a.Order);
        }
    }
}