using System.Data;
using Application.Base;
using Application.Http.Dto;
using Application.Http.Request;
using Microsoft.AspNetCore.Http;

namespace Application.Service.Implementation;

public class AirlineService : BaseService<Airline>, IAirlineService
{
    private readonly IGenericRepository<Airline> _airlineRepository;
    private readonly IMapper _mapper;

    public AirlineService(IGenericRepository<Airline> airlineRepository, IMapper mapper, IHttpContextAccessor httpAccessor) : base(httpAccessor)
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
            SetAuditValuesToEntity(airline);
            var savedAirline = await _airlineRepository.CreateAsync(airline);
            var airlineDto = _mapper.Map<AirlineDto>(savedAirline);
            return new Response<AirlineDto>(HttpStatusCode.OK, "Aereolínea registrada", true, airlineDto);
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
        var airlines = await _airlineRepository.GetAsync(a => a.Status);
        var airlineDtoList = _mapper.Map<IEnumerable<AirlineDto>>(airlines);
        return new Response<IEnumerable<AirlineDto>>
            (HttpStatusCode.OK, "Aereolíneas encontradas", true, airlineDtoList);
    }

    private static void ValidateId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id));
    }

    public async Task<Response<AirlineDto>> GetByIdAsync(Guid id)
    {
        try
        {
            ValidateId(id);
            var airline = await _airlineRepository.FindAsync(id);
            var airlineDto = _mapper.Map<AirlineDto>(airline);
            return new Response<AirlineDto>
                (HttpStatusCode.OK, "Aereolínea encontrada", true, airlineDto);
        }
        catch (Exception e)
        {
            if (e is not ArgumentNullException)
                return new Response<AirlineDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                    false, null!, e);
            return new Response<AirlineDto>(HttpStatusCode.BadRequest, "Seleccione una aereolínea", false, null!, e);
        }
    }

    public async Task<Response<AirlineDto>> UpdateAsync(AirlineUpdateRequest airlineUpdateRequest)
    {
        try
        {
            var oldAirline = _airlineRepository.Find(a => a.Status && a.Id.Equals(airlineUpdateRequest.Id));
            if (oldAirline == null)
                throw new NoNullAllowedException("Aereolínea no encontrada");
            var airline = _mapper.Map<Airline>(airlineUpdateRequest);
            SetAuditValuesToEntity(airline, true);
            _airlineRepository.ClearTracking();
            var airlineUpdated = await _airlineRepository.UpdateAsync(airline);
            var airlineUpdatedDto = _mapper.Map<AirlineDto>(airlineUpdated);
            return new Response<AirlineDto>(HttpStatusCode.OK, "Aereolínea actualizada", true, airlineUpdatedDto);
        }
        catch (Exception e)
        {
            if (e is NoNullAllowedException)
                return new Response<AirlineDto>(HttpStatusCode.BadRequest, "Aereolínea no encontrada", false, null!, e);
            return new Response<AirlineDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<bool>> DeleteAsync(Guid id)
    {
        try
        {
            var airline = await _airlineRepository.FindAsync(id);
            if (airline == null)
                return new Response<bool>(HttpStatusCode.NotFound, "Aereolínea no encontrado", false);

            await _airlineRepository.DeleteAsync(airline);
            return new Response<bool>(HttpStatusCode.OK, "Aereolínea eliminada", true, true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false, e);
        }
    }
}