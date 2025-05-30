using Education.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Education.Migration.Tests;

public class MigrationTestFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSql = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .WithDatabase("risk_education_test")
        .Build();

    private ApiFactory _factory { get; set; }
    private IServiceScope _scope { get; set; }

    public ApplicationDbContext DbContext { get; private set; }

    public async Task InitializeAsync()
    {
        await _postgreSql.StartAsync();

        _factory = new ApiFactory(_postgreSql);

        _scope = _factory.Services.CreateScope();
        DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }

    public async Task DisposeAsync()
    {
        _scope.Dispose();
        await _factory.DisposeAsync();
        await _postgreSql.StopAsync();
        await _postgreSql.DisposeAsync();
    }
}
