using Education.Application.Abstractions.Messaging;
using Education.Persistence.Categories;

namespace Education.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newCategory = Category.Create(request.Title, request.Description);

        _categoryRepository.Add(newCategory, cancellationToken);

        return Task.FromResult(new CreateCategoryCommandResponse(0));
    }
}
