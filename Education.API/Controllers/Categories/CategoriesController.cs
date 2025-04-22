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
    public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken) =>
        Ok(await _sender.Send(new GetAllCategoriesQuery(), cancellationToken));

    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId, CancellationToken cancellationToken)
    {
        GetCategoryQuery query = new(categoryId);

        Result<Category> result = await _sender.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        CreateCategoryCommand command = new(request.Title, request.Description);

        Result result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Created();
    }

    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // request.CategoryId = categoryId;
        return Ok(await _sender.Send(request, cancellationToken));
    }

    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken)
    {
        DeleteCategoryCommand command = new(categoryId);

        Result result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }

        return Ok();
    }
}
