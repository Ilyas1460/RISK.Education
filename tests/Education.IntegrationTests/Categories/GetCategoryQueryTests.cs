using System.Net;
using System.Net.Http.Json;
using Education.Application.Categories.GetCategory;
using Education.Infrastructure;
using Education.Persistence.Categories;
using FluentAssertions;

namespace Education.IntegrationTests.Categories;

[Collection("Integration Tests")]
public class GetCategoryQueryTests
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public GetCategoryQueryTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Fact]
    public async Task Should_Return_Category_When_CategoryExists()
    {
        var category = Category.Create("Test Category");
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();

        var response = await _client.GetAsync($"/api/categories/{category.Id}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<GetCategoryQueryResponse>();
        content.Should().NotBeNull();
        content.Id.Should().Be(category.Id);
        content.Name.Should().Be(category.Name);
    }
}
