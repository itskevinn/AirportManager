﻿using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Base;
using Domain.Repository;
using Infrastructure.Core.Helpers;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Tests.Mocks;

public class FakeRepository<T> where T : DomainEntity
{
	private readonly AppSettings? _appSettings;
	
	public FakeRepository(AppSettings? appSettings)
	{
		_appSettings = appSettings;
	}
	public async Task<IGenericRepository<T>> GetInMemoryRepositoryAsync()
	{
		var options = new DbContextOptionsBuilder<PersistenceContext>().UseInMemoryDatabase(databaseName: "MockDb").Options;
		var context = new PersistenceContext(options, _appSettings);
		await context.Database.EnsureDeletedAsync();
		await context.Database.EnsureCreatedAsync();
		await Populate(context);
		var repo = new GenericRepository<T>(context);
		return repo;
	}

	private static async Task Populate(DbContext context)
	{
		context.Set<Airline>().AddRange(
			new Airline
		{
			Id = Guid.Parse("92C1D573-B7F4-4726-1548-08DA36A80497"),
			Name = "Valledupar",
			Status = true,
			CreatedBy = "yopitip",
			CreatedOn = new DateTime()
		}, new Airline
		{
			Id = Guid.Parse("92C1D573-B7F4-4726-1548-08EA36A80497"),
			Name = "COP",
			Status = true,
			CreatedBy = "yopitip",
			CreatedOn = new DateTime()
		});
		await context.SaveChangesAsync();
	}
}