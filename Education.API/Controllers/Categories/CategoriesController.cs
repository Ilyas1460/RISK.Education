using Education.Application.Categories.CreateACategory;
using Education.Application.Categories.DeleteACategory;
using Education.Application.Categories.GetACategory;
using Education.Application.Categories.GetAllCategories;
using Education.Application.Categories.UpdateACategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers.Categories;

[ApiController]
[Route("api/v1/categories")]
public class CategoriesController : ControllerBase {
    private readonly ISender _sender;
    
    public CategoriesController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken) {
        var query = new GetAllCategoriesQuery();
        
        var result = await _sender.Send(query, cancellationToken);
        
        if (result.IsFailure) {
            return NotFound(result.Error);
        }
        
        return Ok(result.Value);
    }
    
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId, CancellationToken cancellationToken) {
        var query = new GetACategoryQuery(categoryId);
        
        var result = await _sender.Send(query, cancellationToken);
        
        if (result.IsFailure) {
            return NotFound(result.Error);
        }
        
        return Ok(result.Value);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken) {
        var command = new CreateACategoryCommand(request.Title, request.Description);
        
        var result = await _sender.Send(command, cancellationToken);
        
        if (result.IsFailure) {
            return BadRequest(result.Error);
        }

        return Created();
    }
    
    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken) {
        var command = new UpdateACategoryCommand(categoryId, request.Title, request.Description);
        
        var result = await _sender.Send(command, cancellationToken);
        
        if (result.IsFailure) {
            return NotFound(result.Error);
        }

        return Ok();
    }
    
    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken) {
        var command = new DeleteACategoryCommand(categoryId);
        
        var result = await _sender.Send(command, cancellationToken);
        
        if (result.IsFailure) {
            return NotFound(result.Error);
        }

        return Ok();
    }
}