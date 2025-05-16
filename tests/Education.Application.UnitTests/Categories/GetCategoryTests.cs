using Education.Application.Categories.GetCategory;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories;

public class GetCategoryTests
{
    private readonly GetCategoryQuery Query = new(1);

    private readonly GetCategoryQueryHandler _handler;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();

        _handler = new GetCategoryQueryHandler(_categoryRepository);
    }

    [Fact]
    public async Task Handle_Should_ExecuteSuccessfully()
    {
        var category = Category.Create("Test Category");
        _categoryRepository.GetByIdAsync(Query.CategoryId, CancellationToken.None).Returns(category);

        var result = await _handler.Handle(Query, CancellationToken.None);

        await _categoryRepository.Received(1).GetByIdAsync(Query.CategoryId, CancellationToken.None);
        result.Should().BeOfType<GetCategoryQueryResponse>();
        result.Id.Should().Be(category.Id);
        result.Name.Should().Be(category.Name);
        result.CreatedAt.Should().Be(category.CreatedAt);
        result.UpdatedAt.Should().Be(category.UpdatedAt);
    }
}
