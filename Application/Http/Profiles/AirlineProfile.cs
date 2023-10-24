using Application.Http.Dto;
using Application.Http.Request;

namespace Application.Http.Profiles;

public class AirlineProfile : Profile
{
    public AirlineProfile()
    {
        CreateMap<AirlineRequest, Airline>();
        CreateMap<AirlineUpdateRequest, Airline>();
        CreateMap<Airline, AirlineDto>();
    }
}