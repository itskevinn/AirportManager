using System.Net;
using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using Application.Airport.Service.Base;
using Application.Common.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;

namespace Application.Airport.Service;

public class AirlineService : BaseService, IAirlineService
{
    private readonly IGenericRepository<Airline> _airlineRepository;
    private readonly IMapper _mapper;

    public AirlineService(IGenericRepository<Airline> airlineRepository, IMapper mapper)
    {
        _airlineRepository = airlineRepository ??
                             throw new ArgumentNullException(nameof(airlineRepository), "Repositorio no disponible");
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapeador no disponible");
    }

    public async Task<Response<AirlineDto>> SaveAsync(AirlineRequest airlineRequest)
    {
        try
        {
            var airline = _mapper.Map<Airline>(airlineRequest);
            airline = await _airlineRepository.CreateAsync(airline);
            var airlineDto = _mapper.Map<AirlineDto>(airline);
            return new Response<AirlineDto>(HttpStatusCode.OK, "Ciudad registrada", true, airlineDto);
        }
        catch (Exception e)
        {
            return new Response<AirlineDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, null!,
                e);
        }
    }

    public async Task<Response<bool>> SaveAllAsync(IEnumerable<AirlineRequest> airlineRequests)
    {
        try
        {
            var cities = _mapper.Map<IEnumerable<Airline>>(airlineRequests);
            await _airlineRepository.CreateAllAsync(cities);
            return new Response<bool>(HttpStatusCode.OK, "Ciudad registrada", true, true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false, e);
        }
    }

    public async Task<Response<IEnumerable<AirlineDto>>> GetAllAsync()
    {
        try
        {
            var cities = await _airlineRepository.GetAsync();
            var airlineDtoList = _mapper.Map<IEnumerable<AirlineDto>>(cities);
            return new Response<IEnumerable<AirlineDto>>
                (HttpStatusCode.OK, "Ciudades encontradas", true, airlineDtoList);
        }
        catch (Exception e)
        {
            return new Response<IEnumerable<AirlineDto>>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<AirlineDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var airline = await _airlineRepository.FindAsync(id);
            var airlineDto = _mapper.Map<AirlineDto>(airline);
            return new Response<AirlineDto>
                (HttpStatusCode.OK, "Ciudad encontrada", true, airlineDto);
        }
        catch (Exception e)
        {
            return new Response<AirlineDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<bool>> UpdateAsync(AirlineUpdateRequest airlineUpdateRequest)
    {
        try
        {
            var airline = await _airlineRepository.FindAsync(airlineUpdateRequest.Id);
            if (airline == null)
                return new Response<bool>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false);
            airline = _mapper.Map<Airline>(airlineUpdateRequest);
            await _airlineRepository.UpdateAsync(airline);
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
            var airline = await _airlineRepository.FindAsync(id);
            if (airline == null)
                return new Response<Boolean>(HttpStatusCode.NotFound, "Ciudad no encontrado", false);

            await _airlineRepository.DeleteAsync(airline);
            return new Response<Boolean>(HttpStatusCode.OK, "Ciudad eliminada", true, true);
        }
        catch (Exception e)
        {
            return new Response<Boolean>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false, e);
        }
    }
}