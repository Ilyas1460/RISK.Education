﻿using Education.Application.Categories.UpdateCategory;
using Education.Persistence.Categories;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Categories.Handlers;

public class UpdateCategoryHandlerTests
{
    private readonly UpdateCategoryCommandHandler _handler;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandlerTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();
        _handler = new UpdateCategoryCommandHandler(_categoryRepository);
    }

    [Theory]
    [InlineData(1, "Updated Category")]
    public async Task Handle_Should_Pass(int categoryId, string categoryName)
    {
        var command = new UpdateCategoryCommand { CategoryId = categoryId, Name = categoryName };
        var category = Category.Create("Test Category");
        _categoryRepository.GetByIdAsync(command.CategoryId, CancellationToken.None).Returns(category);

        var result = await _handler.Handle(command, CancellationToken.None);

        await _categoryRepository.Received(1).GetByIdAsync(command.CategoryId, CancellationToken.None);
        result.Should().BeOfType<UpdateCategoryCommandResponse>();
        result.Id.Should().Be(result.Id);
    }
}
