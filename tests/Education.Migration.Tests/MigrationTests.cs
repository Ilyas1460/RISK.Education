using Education.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Education.Migration.Tests;

public class MigrationTests : IClassFixture<MigrationTestFixture>
{
    private readonly ApplicationDbContext _dbContext;

    public MigrationTests(MigrationTestFixture fixture)
    {
        _dbContext = fixture.DbContext;
    }

    [Fact]
    public async Task ApplyAllMigrations_Should_Succeed()
    {
        await _dbContext.Database.MigrateAsync();

        var migrations = await _dbContext.Database.GetPendingMigrationsAsync();
        migrations.Should().BeEmpty();

        await _dbContext.Database.OpenConnectionAsync();
        await using var command = _dbContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = "SELECT tablename FROM pg_tables WHERE schemaname = 'public';";

        var tables = new List<string>();
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            tables.Add(reader.GetString(0));
        }

        tables.Count.Should().Be(59);
        tables.Should().Contain("categories");
        tables.Should().Contain("languages");
        tables.Should().Contain("courses");
    }

    [Fact]
    public async Task UpThenDown_AllMigrations_ShouldRollbackSuccessfully()
    {
        var migrator = _dbContext.GetService<IMigrator>();

        var allMigrations = _dbContext.Database.GetMigrations().ToList();
        var lastMigration = allMigrations.Last();

        await migrator.MigrateAsync(lastMigration); // Go up
        await migrator.MigrateAsync("0"); // Rollback everything

        await _dbContext.Database.OpenConnectionAsync();
        await using var command = _dbContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = "SELECT tablename FROM pg_tables WHERE schemaname = 'public';";

        var tables = new List<string>();
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            tables.Add(reader.GetString(0));
        }

        tables.Should().ContainSingle("__EFMigrationsHistory");
    }
}
