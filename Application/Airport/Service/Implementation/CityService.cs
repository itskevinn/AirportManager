using System.Net;
using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using Application.Airport.Service.Base;
using Application.Common.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;

namespace Application.Airport.Service.Implementation;

public class CityService : BaseService, ICityService
{
    private readonly IGenericRepository<City> _cityRepository;
    private readonly IMapper _mapper;

    public CityService(IGenericRepository<City> cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository ??
                          throw new ArgumentNullException(nameof(cityRepository), $"Repositorio no dispoonible");
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), $"Mapeador no disponible");
    }

    public async Task<Response<CityDto>> SaveAsync(CityRequest cityRequest)
    {
        try
        {
            var city = _mapper.Map<City>(cityRequest);
            city = await _cityRepository.CreateAsync(city);
            var cityDto = _mapper.Map<CityDto>(city);
            return new Response<CityDto>(HttpStatusCode.OK, "Ciudad registrada", true, cityDto);
        }
        catch (Exception e)
        {
            return new Response<CityDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, null!, e);
        }
    }

    public async Task<Response<bool>> SaveAllAsync(IEnumerable<CityRequest> cityRequests)
    {
        try
        {
            var cities = _mapper.Map<IEnumerable<City>>(cityRequests);
            await _cityRepository.CreateAllAsync(cities);
            return new Response<bool>(HttpStatusCode.OK, "Ciudad registrada", true, true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false, e);
        }
    }

    public async Task<Response<IEnumerable<CityDto>>> GetAllAsync()
    {
        try
        {
            var cities = await _cityRepository.GetAsync();
            var cityDtoList = _mapper.Map<IEnumerable<CityDto>>(cities);
            return new Response<IEnumerable<CityDto>>
                (HttpStatusCode.OK, "Ciudades encontradas", true, cityDtoList);
        }
        catch (Exception e)
        {
            return new Response<IEnumerable<CityDto>>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<CityDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var city = await _cityRepository.FindAsync(id);
            var cityDto = _mapper.Map<CityDto>(city);
            return new Response<CityDto>
                (HttpStatusCode.OK, "Ciudad encontrada", true, cityDto);
        }
        catch (Exception e)
        {
            return new Response<CityDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<bool>> UpdateAsync(CityUpdateRequest cityUpdateRequest)
    {
        try
        {
            var city = await _cityRepository.FindAsync(cityUpdateRequest.Id);
            if (city == null)
                return new Response<bool>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false);
            city = _mapper.Map<City>(cityUpdateRequest);
            await _cityRepository.UpdateAsync(city);
            return new Response<Boolean>(HttpStatusCode.OK, "Ciudad actualizada", true, true);
        }
        catch (Exception e)
        {
            return new Response<Boolean>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false, e);
        }
    }

    public async Task<Response<bool>> DeleteAsync(Guid id)
    {
        try
        {
            var city = await _cityRepository.FindAsync(id);
            if (city == null)
                return new Response<Boolean>(HttpStatusCode.NotFound, "Ciudad no encontrado", false);

            await _cityRepository.DeleteAsync(city);
            return new Response<Boolean>(HttpStatusCode.OK, "Ciudad eliminada", true, true);
        }
        catch (Exception e)
        {
            return new Response<Boolean>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false, e);
        }
    }
}