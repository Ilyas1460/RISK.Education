using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetByTitleAsync(request.Title, cancellationToken);

        if (category is not null)
        {
            throw new InvalidOperationException("A category with the same title already exists.");
        }

        Category newCategory = new(request.Title, request.Description);

        _categoryRepository.Add(newCategory, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
