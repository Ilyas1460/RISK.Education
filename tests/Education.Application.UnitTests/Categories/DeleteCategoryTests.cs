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
    public async Task Handle_Should_CallCategoryRepositoryDelete()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var category = Category.Create("Test Category");
        _categoryRepository.GetByIdAsync(Command.CategoryId, cancellationToken).Returns(category);

        // Act
        await _handler.Handle(Command, cancellationToken);

        // Assert
        _categoryRepository.Received(1).Delete(category, cancellationToken);
    }

    [Fact]
    public async Task Handle_Should_CallCategoryRepositoryGetByIdAsync()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var category = Category.Create("Test Category");
        _categoryRepository.GetByIdAsync(Command.CategoryId, cancellationToken).Returns(category);

        // Act
        await _handler.Handle(Command, cancellationToken);

        // Assert
        await _categoryRepository.Received(1).GetByIdAsync(Command.CategoryId, cancellationToken);
    }

    [Fact]
    public async Task Handle_Should_ReturnDeleteCategoryCommandResponse()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var category = Category.Create("Test Category");
        _categoryRepository.GetByIdAsync(Command.CategoryId, cancellationToken).Returns(category);

        // Act
        var result = await _handler.Handle(Command, cancellationToken);

        // Assert
        result.Should().BeOfType<DeleteCategoryCommandResponse>();
        result.Id.Should().Be(0); // Adjust it in future to return the actual ID
    }
}
