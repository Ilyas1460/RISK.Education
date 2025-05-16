using Education.Application.Categories.GetAllCategories;
using Education.Application.Categories.GetCategory;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories;

public class GetAllCategoriesTests
{
    private readonly GetAllCategoriesQuery Query = new();

    private readonly GetAllCategoriesQueryHandler _handler;
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();

        _handler = new GetAllCategoriesQueryHandler(_categoryRepository);
    }

    [Fact]
    public async Task Handle_Should_ExecuteSuccessfully()
    {
        var categories = new List<Category>
        {
            Category.Create("Category 1"),
            Category.Create("Category 2")
        };
        _categoryRepository.GetAllAsync(CancellationToken.None).Returns(categories);

        var result = await _handler.Handle(Query, CancellationToken.None);

        await _categoryRepository.Received(1).GetAllAsync(CancellationToken.None);
        result.Should().BeOfType<GetAllCategoriesQueryResponse>();
        result.Categories.Should().Contain(categories
            .Select(c => new GetCategoryQueryResponse(
                c.Id,
                c.Name,
                c.CreatedAt,
                c.UpdatedAt)));
    }
}
