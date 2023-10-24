using Application.Http.Dto;
using Application.Http.Request;

namespace Application.Http.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityUpdateRequest, City>().ReverseMap();
        CreateMap<CityRequest, City>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
    }
}