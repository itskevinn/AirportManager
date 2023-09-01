using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;

namespace Application.Airport.Http.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityUpdateRequest, City>().ReverseMap();
        CreateMap<CityRequest, City>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
    }
}