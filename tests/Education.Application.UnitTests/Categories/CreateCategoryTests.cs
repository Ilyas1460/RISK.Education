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
    public async Task Handle_Should_ExecuteSuccessfully()
    {
        var result = await _handler.Handle(Command, CancellationToken.None);

        _categoryRepository.Received(1).Add(Arg.Is<Category>(c => c.Name == Command.Name), CancellationToken.None);
        result.Should().BeOfType<CreateCategoryCommandResponse>();
        result.Id.Should().Be(0); // Adjust it in future to return the actual ID
    }
}
