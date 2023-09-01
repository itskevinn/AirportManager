﻿using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;

namespace Application.Airport.Http.Profiles;

public class AirlineProfile : Profile
{
    public AirlineProfile()
    {
        CreateMap<AirlineRequest, Airline>();
        CreateMap<AirlineUpdateRequest, Airline>();
        CreateMap<Airline, AirlineDto>();
    }
}