using System.Net;
using System.Net.Http.Json;
using Education.Application.Categories.DeleteCategory;
using Education.Exceptions.Exceptions;
using Education.Infrastructure;
using Education.IntegrationTests.Common;
using Education.IntegrationTests.Common.Response;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Education.IntegrationTests.Categories;

public class DeleteCategoryCommandTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public DeleteCategoryCommandTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData(CategoryConstants.SampleCategoryId)]
    public async Task Should_Delete_Category_When_CategoryExists(int categoryId)
    {
        var response = await _client.DeleteAsync($"/api/categories/{categoryId}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<DeleteCategoryCommandResponse>();

        content.Should().NotBeNull();
        content.Id.Should().Be(categoryId);

        var deletedCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        deletedCategory.Should().BeNull();
    }

    [Theory]
    [InlineData(CategoryConstants.NonExistentCategoryId)]
    public async Task Should_Return_NotFound_When_CategoryDoesNotExist(int categoryId)
    {
        var response = await _client.DeleteAsync($"/api/categories/{categoryId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(NotFoundException));
        content.Detail.Should().Be($"Category with ID {categoryId} not found.");
        content.Status.Should().Be((int)HttpStatusCode.NotFound);
    }

    [Theory]
    [InlineData(CategoryConstants.EmptyCategoryId)]
    public async Task Should_Return_BadRequest_When_CategoryIdIsEmpty(int categoryId)
    {
        var response = await _client.DeleteAsync($"/api/categories/{categoryId}");

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ValidationException));
        content.Detail.Should().Be("One or more validation errors occurred.");
        content.Status.Should().Be((int)HttpStatusCode.BadRequest);
        content.Errors.Should().ContainKey("CategoryId");
        content.Errors["CategoryId"].Should().Contain("Category ID must not be empty.");
    }
}
