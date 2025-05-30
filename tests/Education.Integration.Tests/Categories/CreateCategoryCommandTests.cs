using System.Net;
using System.Net.Http.Json;
using Education.Application.Categories.CreateCategory;
using Education.Exceptions.Exceptions;
using Education.Infrastructure;
using Education.Integration.Tests.Common;
using Education.Integration.Tests.Common.Response;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Education.Integration.Tests.Categories;

public class CreateCategoryCommandTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public CreateCategoryCommandTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData("Programming")]
    public async Task Should_Create_Category_When_ValidDataProvided(string categoryName)
    {
        var command = new CreateCategoryCommand(categoryName);
        var response = await _client.PostAsJsonAsync("/api/categories", command);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var content = await response.Content.ReadFromJsonAsync<CreateCategoryCommandResponse>();
        content.Should().NotBeNull();

        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        category.Should().NotBeNull();
    }

    [Theory]
    [InlineData(CategoryConstants.EmptyCategoryName)]
    public async Task Should_Return_BadRequest_When_CategoryNameIsEmpty(string categoryName)
    {
        var command = new CreateCategoryCommand(categoryName);
        var response = await _client.PostAsJsonAsync("/api/categories", command);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ValidationException));
        content.Detail.Should().Be("One or more validation errors occurred.");
        content.Status.Should().Be((int)HttpStatusCode.BadRequest);
        content.Errors.Should().ContainKey("Name");
        content.Errors["Name"].Should().Contain("Name is required.");
    }

    [Theory]
    [InlineData(CategoryConstants.SampleCategoryName)]
    public async Task Should_Return_Conflict_When_CategoryNameAlreadyExists(string categoryName)
    {
        var command = new CreateCategoryCommand(categoryName);
        var response = await _client.PostAsJsonAsync("/api/categories", command);

        response.StatusCode.Should().Be(HttpStatusCode.Conflict);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ConflictException));
        content.Detail.Should().Be($"Category with title '{categoryName}' already exists.");
        content.Status.Should().Be((int)HttpStatusCode.Conflict);
    }
}
