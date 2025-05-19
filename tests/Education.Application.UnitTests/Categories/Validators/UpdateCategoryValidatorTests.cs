using Education.Application.Categories.UpdateCategory;
using Education.Exceptions.Exceptions;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories.Validators;

public class UpdateCategoryValidatorTests
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly UpdateCategoryCommandValidator _validator;

    public UpdateCategoryValidatorTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();
        _validator = new UpdateCategoryCommandValidator(_categoryRepository);
    }

    [Theory]
    [InlineData(1, "New Test Category")]
    public async Task Should_Pass_When_ValidData(int categoryId, string categoryName)
    {
        var command = new UpdateCategoryCommand { CategoryId = categoryId, Name = categoryName};
        _categoryRepository.GetByIdAsync(categoryId, CancellationToken.None).Returns(Category.Create("Old Test Category"));
        _categoryRepository.GetByNameAsync(categoryName, CancellationToken.None).Returns((Category)null!);

        var result = await _validator.ValidateAsync(command);

        result.Errors.Should().BeEmpty();
        result.IsValid.Should().BeTrue();
        await _categoryRepository.Received(1).GetByIdAsync(categoryId, CancellationToken.None);
        await _categoryRepository.Received(1).GetByNameAsync(categoryName, CancellationToken.None);
    }

    [Theory]
    [InlineData(1, "New Test Category")]
    public async Task Should_Fail_When_CategoryDoesNotExist(int categoryId, string categoryName)
    {
        var command = new UpdateCategoryCommand { CategoryId = categoryId, Name = categoryName };
        _categoryRepository.GetByIdAsync(categoryId, CancellationToken.None).Returns((Category)null!);

        var act = async () => await _validator.ValidateAsync(command);

        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Category with ID {categoryId} not found.");
        await _categoryRepository.Received(1).GetByIdAsync(categoryId, CancellationToken.None);
    }

    [Theory]
    [InlineData(1, "New Test Category")]
    public async Task Should_Fail_When_CategoryNameAlreadyExists(int categoryId, string categoryName)
    {
        var command = new UpdateCategoryCommand { CategoryId = categoryId, Name = categoryName };
        _categoryRepository.GetByIdAsync(categoryId, CancellationToken.None).Returns(Category.Create("Old Test Category"));
        _categoryRepository.GetByNameAsync(categoryName, CancellationToken.None).Returns(Category.Create(categoryName));

        var act = async () => await _validator.ValidateAsync(command);

        await act.Should().ThrowAsync<ConflictException>()
            .WithMessage($"Category with title '{categoryName}' already exists.");
        await _categoryRepository.Received(1).GetByIdAsync(categoryId, CancellationToken.None);
        await _categoryRepository.Received(1).GetByNameAsync(categoryName, CancellationToken.None);
    }
}
