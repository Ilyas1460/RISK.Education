using Education.Application.Categories.DeleteCategory;
using Education.Exceptions.Exceptions;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories.Validators;

public class DeleteCategoryValidatorTests
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly DeleteCategoryCommandValidator _validator;

    public DeleteCategoryValidatorTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();
        _validator = new DeleteCategoryCommandValidator(_categoryRepository);
    }

    [Theory]
    [InlineData(1)]
    public async Task Should_Pass_When_ValidData(int categoryId)
    {
        var command = new DeleteCategoryCommand(categoryId);
        _categoryRepository.GetByIdAsync(categoryId, CancellationToken.None).Returns(Category.Create("Test Category"));

        var result = await _validator.ValidateAsync(command);

        result.Errors.Should().BeEmpty();
        result.IsValid.Should().BeTrue();
        await _categoryRepository.Received(1).GetByIdAsync(categoryId, CancellationToken.None);
    }

    [Theory]
    [InlineData(1)]
    public async Task Should_Fail_When_CategoryDoesNotExist(int categoryId)
    {
        var command = new DeleteCategoryCommand(categoryId);
        _categoryRepository.GetByIdAsync(categoryId, CancellationToken.None).Returns((Category)null!);

        var act = async () => await _validator.ValidateAsync(command);

        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Category with ID {categoryId} not found.");
        await _categoryRepository.Received(1).GetByIdAsync(categoryId, CancellationToken.None);
    }
}
