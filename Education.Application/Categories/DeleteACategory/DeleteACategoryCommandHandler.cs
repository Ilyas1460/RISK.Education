using Education.Application.Abstractions.Messaging;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Application.Categories.DeleteACategory;

public class DeleteACategoryCommandHandler : ICommandHandler<DeleteACategoryCommand> {
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteACategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(DeleteACategoryCommand request, CancellationToken cancellationToken) {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        
        if (category is null) {
            return Result.Failure(CategoryErrors.NotFound(request.CategoryId));
        }
        
        _categoryRepository.Delete(category, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}