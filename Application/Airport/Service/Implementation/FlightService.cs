using System.Net;
using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using Application.Airport.Service.Base;
using Application.Common.Response;
using AutoMapper;
using Domain.Repository;

namespace Application.Airport.Service;

public class FlightService : BaseService, IFlightService
{
    private readonly IGenericRepository<Domain.Entities.Flight> _flightRepository;
    private readonly IMapper _mapper;

    public FlightService(IGenericRepository<Domain.Entities.Flight> flightRepository,
        IMapper mapper)
    {
        _flightRepository = flightRepository;
        _mapper = mapper;
    }

    public async Task<Response<FlightDto>> SaveAsync(FlightRequest flightRequest)
    {
        try
        {
            var flight = _mapper.Map<Domain.Entities.Flight>(flightRequest);
            flight = await _flightRepository.CreateAsync(flight);
            var flightDto = _mapper.Map<FlightDto>(flight);
            return new Response<FlightDto>(HttpStatusCode.OK, "Vuelo registrado", true, flightDto);
        }
        catch (Exception e)
        {
            return new Response<FlightDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, null!, e);
        }
    }

    public async Task<Response<IEnumerable<FlightDto>>> GetAllAsync()
    {
        try
        {
            var flights = await _flightRepository.GetAsync();
            var flightDtoList = _mapper.Map<IEnumerable<FlightDto>>(flights);
            return new Response<IEnumerable<FlightDto>>
                (HttpStatusCode.OK, "Vuelos encontrados", true, flightDtoList);
        }
        catch (Exception e)
        {
            return new Response<IEnumerable<FlightDto>>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<FlightDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var flight = await _flightRepository.FindAsync(id);
            var flightDto = _mapper.Map<FlightDto>(flight);
            return new Response<FlightDto>
                (HttpStatusCode.OK, "Vuelo encontrado", true, flightDto);
        }
        catch (Exception e)
        {
            return new Response<FlightDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<bool>> UpdateAsync(FlightUpdateRequest flightUpdateRequest)
    {
        try
        {
            var flight = await _flightRepository.FindAsync(flightUpdateRequest.Id);
            flight = _mapper.Map<Domain.Entities.Flight>(flightUpdateRequest);
            await _flightRepository.UpdateAsync(flight);
            return new Response<Boolean>(HttpStatusCode.OK, "Vuelo actualizado", true, true);
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
            var flight = await _flightRepository.FindAsync(id);
            if (flight == null)
                return new Response<Boolean>(HttpStatusCode.NotFound, "Vuelo no encontrado", false);

            await _flightRepository.DeleteAsync(flight);
            return new Response<Boolean>(HttpStatusCode.OK, "Vuelo eliminado", true, true);
        }
        catch (Exception e)
        {
            return new Response<Boolean>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false, e);
        }
    }
}