using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using AutoMapper;
using Domain.Entities;

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