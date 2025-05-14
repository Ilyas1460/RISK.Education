using Education.Application.Categories.CreateCategory;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories;

public class CreateCategoryTests
{
    private readonly CreateCategoryCommand Command = new("Test Category");

    private readonly CreateCategoryCommandHandler _handler;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();

        _handler = new CreateCategoryCommandHandler(_categoryRepository);
    }

    [Fact]
    public async Task Handle_Should_CallCategoryRepositoryAdd()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;

        // Act
        await _handler.Handle(Command, cancellationToken);

        // Assert
        _categoryRepository.Received(1).Add(Arg.Is<Category>(c => c.Name == Command.Name), cancellationToken);
    }

    [Fact]
    public async Task Handle_Should_ReturnCreateCategoryCommandResponse()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(Command, cancellationToken);

        // Assert
        result.Should().BeOfType<CreateCategoryCommandResponse>();
        result.Id.Should().Be(0); // Adjust it in future to return the actual ID
    }
}
