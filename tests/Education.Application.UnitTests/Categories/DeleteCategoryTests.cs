using Education.Application.Categories.DeleteCategory;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories;

public class DeleteCategoryTests
{
    private readonly DeleteCategoryCommand Command = new(1);

    private readonly DeleteCategoryCommandHandler _handler;
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();

        _handler = new DeleteCategoryCommandHandler(_categoryRepository);
    }

    [Fact]
    public async Task Handle_Should_ExecuteSuccessfully()
    {
        var category = Category.Create("Test Category");
        _categoryRepository.GetByIdAsync(Command.CategoryId, CancellationToken.None).Returns(category);

        var result = await _handler.Handle(Command, CancellationToken.None);

        await _categoryRepository.Received(1).GetByIdAsync(Command.CategoryId, CancellationToken.None);
        _categoryRepository.Received(1).Delete(category, CancellationToken.None);
        result.Should().BeOfType<DeleteCategoryCommandResponse>();
        result.Id.Should().Be(0); // Adjust it in future to return the actual ID
    }
}
