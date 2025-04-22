using Education.Application.Abstractions.Messaging;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Application.Categories.CreateCategory;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetByTitleAsync(request.Title, cancellationToken);

        if (category is not null)
        {
            return Result.Failure(CategoryErrors.AlreadyExists(request.Title));
        }

        Category newCategory = new(request.Title, request.Description);

        _categoryRepository.Add(newCategory, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
