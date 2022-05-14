using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using AutoMapper;

namespace Application.Airport.Http.Profiles;

public class FlightProfile : Profile
{
    public FlightProfile()
    {
        CreateMap<Domain.Entities.Flight, FlightDto>().ReverseMap();
        CreateMap<FlightRequest, Domain.Entities.Flight>().ReverseMap();
    }
}