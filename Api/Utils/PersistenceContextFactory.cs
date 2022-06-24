﻿using Infrastructure.Extensions;
using Infrastructure.Helpers;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Utils;

public class PersistenceContextFactory : IDesignTimeDbContextFactory<PersistenceContext>
{
	public PersistenceContext CreateDbContext(string[] args)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var optionsBuilder = new DbContextOptionsBuilder<PersistenceContext>();
		optionsBuilder.UseSqlServer(config.GetConnectionString("local"),
			sqlOpts => { sqlOpts.MigrationsHistoryTable("_MigrationHistory", config.GetValue<string>("SchemaName")); });

		return new PersistenceContext(optionsBuilder.Options, new RepoSettings());
	}
}