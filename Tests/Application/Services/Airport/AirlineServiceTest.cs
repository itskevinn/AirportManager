using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Application.Airport.Http.Dto;
using Application.Airport.Http.Profiles;
using Application.Airport.Http.Request;
using Application.Airport.Service.Implementation;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Response;
using Microsoft.EntityFrameworkCore;
using Tests.Mocks;
using Xunit;

namespace Tests.Application.Services.Airport;

public class AirlineServiceTest
{
	private readonly MapperConfiguration _mapperConfig = new(cfg => { cfg.AddProfile(new AirlineProfile()); });
	private readonly IMapper _airlineMapper;

	public AirlineServiceTest()
	{
		_airlineMapper = _mapperConfig.CreateMapper();
	}
	[Fact]
	public async Task AirlineService_GetAll_ReturnsAirlines()
	{
		//Arrange
		var fakeAirlineRepo = new FakeRepository<Airline>().GetInMemoryRepositoryAsync();

		var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);

		//Act
		var result = await airlineService.GetAllAsync();

		//Assert
		var airlineDtoList = result.Data.AsQueryable();
		Assert.NotEmpty(airlineDtoList);
		Assert.Equal(2, airlineDtoList.Count());
	}


	[Fact]
	public async Task AirlineService_FindByEmptyId_ThrowsArgumentNullException()
	{
		//Arrange
		var fakeAirlineRepo = new FakeRepository<Airline>().GetInMemoryRepositoryAsync();
		var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);

		//Act
		var result = await airlineService.GetByIdAsync(Guid.Empty);
		//Assert
		Assert.IsType<ArgumentNullException>(result.Exception);
	}

	[Fact]
	public async Task AirlineService_FindById_ReturnsAirline()
	{
		//Arrange
		const string id = "92C1D573-B7F4-4726-1548-08EA36A80497";
		var fakeAirlineRepo = new FakeRepository<Airline>().GetInMemoryRepositoryAsync();
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
		var fakeAirlineRepo = new FakeRepository<Airline>().GetInMemoryRepositoryAsync();

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
	public async Task AirlineService_Save_ThrowsDbUpdateException()
	{
		//Arrange
		var fakeAirlineRepo = new FakeRepository<Airline>().GetInMemoryRepositoryAsync();

		var airlineRequest = new AirlineRequest()
		{
			Name = null!,
			CreatedBy = null!
		};
		var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);
		//Action
		var result = await airlineService.SaveAsync(airlineRequest);
		//Assert
		Assert.IsType<DbUpdateException>(result.Exception);
	}

	[Fact]
	public async Task AirlineService_Update_ThrowsKeyNotFoundException()
	{
		//Arrange
		var airlineRequest = new AirlineUpdateRequest
		{
			Id = Guid.Parse("A2C1D573-B7F4-4726-1548-081836A80497"),
			Name = "PORTO",
			UpdatedBy = "YOPITIP"
		};
		var fakeAirlineRepo = new FakeRepository<Airline>().GetInMemoryRepositoryAsync();

		var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);

		//Act
		var result = await airlineService.UpdateAsync(airlineRequest);
		//Assert
		Assert.IsType<NoNullAllowedException>(result.Exception);
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
		var fakeAirlineRepo = new FakeRepository<Airline>().GetInMemoryRepositoryAsync();
		var airlineService = new AirlineService(await fakeAirlineRepo, _airlineMapper);

		//Act
		var result = await airlineService.UpdateAsync(airlineRequest);

		//Assert
		Assert.NotNull(result);
		Assert.Equal(Guid.Parse(id), result.Data.Id);
		Assert.Equal(airlineRequest.Name, result.Data.Name);
	}
}