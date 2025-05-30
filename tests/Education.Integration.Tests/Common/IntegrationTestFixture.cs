using Education.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Education.Integration.Tests.Common;

public class IntegrationTestFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSql = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .WithDatabase("risk_education_test")
        .Build();

    private ApiFactory _factory { get; set; }
    private IServiceScope _scope { get; set; }

    public HttpClient Client { get; private set; }
    public ApplicationDbContext DbContext { get; private set; }

    public async Task InitializeAsync()
    {
        await _postgreSql.StartAsync();

        _factory = new ApiFactory(_postgreSql);

        _scope = _factory.Services.CreateScope();
        DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await DbContext.Database.MigrateAsync();

        var path = Path.Combine(AppContext.BaseDirectory, "Common", "Seed", "seedData.sql");
        var sql = await File.ReadAllTextAsync(path);

        await DbContext.Database.ExecuteSqlRawAsync(sql);

        Client = _factory.CreateClient();
    }

    public async Task DisposeAsync()
    {
        _scope.Dispose();
        await _factory.DisposeAsync();
        await _postgreSql.StopAsync();
        await _postgreSql.DisposeAsync();
    }
}
