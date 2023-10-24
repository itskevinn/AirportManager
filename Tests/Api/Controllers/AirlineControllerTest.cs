using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Controllers;
using Application.Http.Profiles;
using Application.Service.Implementation;
using AutoMapper;
using Moq;
using Xunit;

namespace Tests.Api.Controllers;

public class AirlineControllerTest
{
    private readonly MapperConfiguration _mapperConfig = new(cfg => { cfg.AddProfile(new AirlineProfile()); });

    private readonly IMapper _airlineMapper;

    public AirlineControllerTest()
    {
        _airlineMapper = _mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task AirlineController_GetAll_ShouldReturnAirlines()
    {
        //Arrange
        var airlineServiceMock = new Mock<AirlineService>();
        var airlineController = new AirlineController(airlineServiceMock.Object);

        //Act
        var result = await airlineController.GetAll();

        //Assert
        var airlineDtoList = result.Data.ToList();
        Assert.NotEmpty(airlineDtoList);
        Assert.Equal(2, airlineDtoList.Count);
        Assert.Equal((HttpStatusCode)200, result.StatusCode);
        Assert.True(result.Success);

    }

    [Fact]
    public async Task AirlineService_FindById_ReturnsAirline()
    {
        //Arrange
        var airlineServiceMock = new Mock<AirlineService>();
        var airlineController = new AirlineController(airlineServiceMock.Object);

        //Act
        var result = await airlineController.GetById(new Guid("92C1D573-B7F4-4726-1548-08EA36A80497"));

        //Assert
        var airlineDto = result.Data;
        Assert.NotNull(airlineDto);
        Assert.Equal((HttpStatusCode)200, result.StatusCode);
        Assert.True(result.Success);
    }

   
    [Fact]
    public async Task AirlineService_FindByEmptyId_ThrowsArgumentNullException()
    {
        //Arrange
        var airlineServiceMock = new Mock<AirlineService>();
        var airlineController = new AirlineController(airlineServiceMock.Object);

        //Act
        var result = await airlineController.GetById(Guid.Empty);

        //Assert
        var airlineDto = result.Data;
        Assert.NotNull(airlineDto);
        Assert.Equal((HttpStatusCode)400, result.StatusCode);
        Assert.False(result.Success);
    }
}