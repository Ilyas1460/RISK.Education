using Education.Application.Categories.CreateCategory;
using Education.Persistence.Categories;
using NSubstitute;

namespace Education.Application.UnitTests.Categories;

public class CreateCategoryTests
{
    private static readonly CreateCategoryCommand Command = new("Test Category");

    private readonly CreateCategoryCommandHandler _handler;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();

        _handler = new CreateCategoryCommandHandler(_categoryRepository);
    }
}
