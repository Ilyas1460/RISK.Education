using Education.Persistence.Categories;
using FluentAssertions;

namespace Education.Persistence.UnitTests.Categories;

public class CategoryTests
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        // Arrange
        var name = "Test Category";

        // Act
        var category = Category.Create(name);

        // Assert
        category.Name.Should().Be(name);
    }
}
