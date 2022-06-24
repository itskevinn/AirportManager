using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using AutoMapper;

namespace Application.Airport.Http.Profiles;

public class FlightProfile : Profile
{
	public FlightProfile()
	{
		CreateMap<Flight, FlightDto>().ReverseMap()
			.ForMember(f => f.Airline,
				af =>
					af.MapFrom(a => new AirlineDto()
					{
						Name = a.Airline.Name
					}))
			.ForMember(f => f.DepartureCity,
				af =>
					af.MapFrom(a => new CityDto()
					{
						Name = a.DepartureCity.Name
					}))
			.ForMember(f => f.DestinyCity,
				af =>
					af.MapFrom(a => new CityDto()
					{
						Name = a.DestinyCity.Name
					}));
		CreateMap<FlightRequest, Flight>().ReverseMap();
		CreateMap<FlightUpdateRequest, Flight>().ReverseMap();
	}
}