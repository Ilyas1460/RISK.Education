using Education.Application.Categories.GetCategory;
using Education.Persistence.Categories;
using FluentAssertions;

namespace Education.IntegrationTests.Categories;

public class GetCategoryQueryTests : BaseIntegrationTest
{
    public GetCategoryQueryTests(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Should_Return_Category_When_CategoryExists()
    {
        var category = Category.Create("Test Category");
        DbContext.Categories.Add(category);
        await DbContext.SaveChangesAsync();

        var query = new GetCategoryQuery(category.Id);
        var result = await Sender.Send(query);

        result.Should().NotBeNull();
        result.Id.Should().Be(category.Id);
        result.Name.Should().Be(category.Name);
        result.CreatedAt.Should().Be(category.CreatedAt);
        result.UpdatedAt.Should().Be(category.UpdatedAt);
    }
}
