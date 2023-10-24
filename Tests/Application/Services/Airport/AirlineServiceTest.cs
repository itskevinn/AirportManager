using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Http.Profiles;
using Application.Http.Request;
using Application.Service.Implementation;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Core.Helpers;
using Tests.Mocks;
using Xunit;

namespace Tests.Application.Services.Airport;

public class AirlineServiceTest
{
    private readonly MapperConfiguration _mapperConfig = new(cfg => { cfg.AddProfile(new AirlineProfile()); });
    private readonly IMapper _airlineMapper;
    private readonly AppSettings? _appSettings = Helper.GetAppSettings();

    public AirlineServiceTest()
    {
        _airlineMapper = _mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task AirlineService_GetAll_ReturnsAirlines()
    {
        //Arrange
        var fakeAirlineRepo = new FakeRepository<Airline>(_appSettings).GetInMemoryRepositoryAsync();

        var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);

        //Act
        var result = await airlineService.GetAllAsync();

        //Assert
        var airlineDtoList = result.Data.AsQueryable();
        Assert.NotEmpty(airlineDtoList);
        Assert.Equal(2, airlineDtoList.Count());
    }

    [Fact]
    public async Task AirlineService_FindById_ReturnsAirline()
        {
        //Arrange
        const string id = "92C1D573-B7F4-4726-1548-08EA36A80497";
        var fakeAirlineRepo = new FakeRepository<Airline>(_appSettings).GetInMemoryRepositoryAsync();
        var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);

        //Act
        var result = airlineService.GetByIdAsync(Guid.Parse(id));
        //Assert
        Assert.NotNull(result.Result.Data);
    }

    [Fact]
    public async Task AirlineService_Save_ReturnAirlineSaved()
    {
        //Arrange
        var fakeAirlineRepo = new FakeRepository<Airline>(_appSettings).GetInMemoryRepositoryAsync();

        var airlineRequest = new AirlineRequest()
        {
            Name = "LAN",
            CreatedBy = "Admin"
        };
        var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);
        //Action
        var result = airlineService.SaveAsync(airlineRequest).Result.Data;
        //Assert
        Assert.NotNull(result);
    }


    [Fact]
    public async Task AirlineService_Update_ReturnsAirlineUpdated()
    {
        //Arrange
        const string id = "92C1D573-B7F4-4726-1548-08DA36A80497";
        var airlineRequest = new AirlineUpdateRequest
        {
            Id = Guid.Parse("92C1D573-B7F4-4726-1548-08DA36A80497"),
            Name = "PORTO",
            UpdatedBy = "YOPITIP"
        };
        var fakeAirlineRepo = new FakeRepository<Airline>(_appSettings).GetInMemoryRepositoryAsync();
        var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);

        //Act
        var result = await airlineService.UpdateAsync(airlineRequest);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(Guid.Parse(id), result.Data.Id);
        Assert.Equal(airlineRequest.Name, result.Data.Name);
    }
}