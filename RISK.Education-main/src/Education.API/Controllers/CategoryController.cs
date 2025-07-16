﻿using Education.Application.Categories.CreateCategory;
using Education.Application.Categories.DeleteCategory;
using Education.Application.Categories.GetAllCategories;
using Education.Application.Categories.GetCategory;
using Education.Application.Categories.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers;

[ApiController]
[Route("api/categories")]
public sealed class CategoryController : ControllerBase
{
    private readonly IMediator _sender;

    public CategoryController(IMediator sender) => _sender = sender;

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
        var result = await _sender.Send(request, cancellationToken);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = result.Id }, result);
    }

    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        request.CategoryId = categoryId;
        return Ok(await _sender.Send(request, cancellationToken));
    }

    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new DeleteCategoryCommand(categoryId), cancellationToken));
    }
}
