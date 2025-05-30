using System.Net;
using System.Net.Http.Json;
using Education.Application.Categories.GetAllCategories;
using Education.Infrastructure;
using Education.Integration.Tests.Common;
using FluentAssertions;

namespace Education.Integration.Tests.Categories;

public class GetAllCategoriesQueryTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public GetAllCategoriesQueryTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData(CategoryConstants.RecordsCount,
        CategoryConstants.SampleCategoryId,
        CategoryConstants.SampleCategoryName)]
    public async Task Should_Return_All_Categories_When_CategoriesExist(int expectedCount,
        int categoryId,
        string categoryName)
    {
        var response = await _client.GetAsync("/api/categories");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<GetAllCategoriesQueryResponse>();
        content.Should().NotBeNull();
        content.Categories.Should().HaveCount(expectedCount);
        content.Categories.Should().Contain(c => c.Id == categoryId && c.Name == categoryName);
    }
}
