using HotChocolateAutoMapperProjectionIssue;
using HotChocolateAutoMapperProjectionIssue.Repository;
using HotChocolateAutoMapperProjectionIssue.Schema;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections();

builder.Services.AddPooledDbContextFactory<AutomobileRepository>(contextOptions =>
{
    contextOptions.EnableDetailedErrors();
    contextOptions.EnableSensitiveDataLogging();
    contextOptions.LogTo(e => Debug.WriteLine(e), minimumLevel: LogLevel.Information);

    contextOptions.UseSqlite(SqliteConnectionProvider.GetSqliteConnection());
});

var app = builder.Build();

// Create and seed in-memory database
var contextFactory = app.Services.GetRequiredService<IDbContextFactory<AutomobileRepository>>();
using var context = contextFactory.CreateDbContext();
context.Database.EnsureCreated();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();