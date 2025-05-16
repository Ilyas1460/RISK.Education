using Education.Application.Categories.UpdateCategory;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories;

public class UpdateCategoryTests
{
    private readonly UpdateCategoryCommand Command = new();

    private readonly UpdateCategoryCommandHandler _handler;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();
        _handler = new UpdateCategoryCommandHandler(_categoryRepository);
    }

    [Fact]
    public async Task Handle_Should_ExecuteSuccessfully()
    {
        var category = Category.Create("Test Category");
        _categoryRepository.GetByIdAsync(Command.CategoryId, CancellationToken.None).Returns(category);

        var result = await _handler.Handle(Command, CancellationToken.None);

        await _categoryRepository.Received(1).GetByIdAsync(Command.CategoryId, CancellationToken.None);
        result.Should().BeOfType<UpdateCategoryCommandResponse>();
        result.Id.Should().Be(0); // Adjust it in future to return the actual ID
    }
}
