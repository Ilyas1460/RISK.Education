using Education.Application.Abstractions.Messaging;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Application.Categories.UpdateACategory;

public class UpdateACategoryCommandHandler : ICommandHandler<UpdateACategoryCommand> {
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateACategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(UpdateACategoryCommand request, CancellationToken cancellationToken) {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        
        if (category is null) {
            return Result.Failure(CategoryErrors.NotFound(request.CategoryId));
        }
        
        category.UpdateTitle(request.NewTitle);
        category.UpdateDescription(request.NewDescription);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}