using Education.Persistence.Categories;
using FluentAssertions;

namespace Education.Persistence.UnitTests.Categories;

public class CategoryTests
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        var name = "Test Category";

        var category = Category.Create(name);

        category.Name.Should().Be(name);
    }
}
