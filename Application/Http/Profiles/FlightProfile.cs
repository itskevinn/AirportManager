using Application.Http.Dto;
using Application.Http.Request;

namespace Application.Http.Profiles;

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