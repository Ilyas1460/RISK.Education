using Education.Infrastructure.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Education.Infrastructure.MigrationTests;

internal sealed class ApiFactory : WebApplicationFactory<Program>
{
    private readonly PostgreSqlContainer _postgres;

    public ApiFactory(PostgreSqlContainer postgres)
    {
        _postgres = postgres;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            services.Remove(descriptor);

            services.AddApplicationDbContext(_postgres.GetConnectionString());

            services
                .AddControllers()
                .AddApplicationPart(typeof(Program).Assembly);
        });
    }
}
