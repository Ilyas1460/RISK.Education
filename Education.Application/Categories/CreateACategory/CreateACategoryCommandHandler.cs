using Education.Application.Abstractions.Messaging;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Application.Categories.CreateACategory;

public class CreateACategoryCommandHandler : ICommandHandler<CreateACategoryCommand> {
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateACategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateACategoryCommand request, CancellationToken cancellationToken) {
        var category = await _categoryRepository.GetByTitleAsync(request.Title, cancellationToken);
        
        if (category is not null) {
            return Result.Failure(CategoryErrors.AlreadyExists(request.Title));
        }
        
        var newCategory = new Category(request.Title, request.Description);
        
        _categoryRepository.Add(newCategory, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}