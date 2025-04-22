using Education.Application.Categories.CreateCategory;
using Education.Application.Categories.DeleteCategory;
using Education.Application.Categories.GetAllCategories;
using Education.Application.Categories.GetCategory;
using Education.Application.Categories.UpdateCategory;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers.Categories;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _sender;

    public CategoriesController(IMediator sender) => _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetAllCategoriesQuery(), cancellationToken));
    }

    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetCategoryQuery(categoryId), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        await _sender.Send(request, cancellationToken);
        return Created();
    }

    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        request.CategoryId = categoryId;
        await _sender.Send(request, cancellationToken);
        return Ok();
    }

    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCategoryCommand(categoryId), cancellationToken);
        return Ok();
    }
}
