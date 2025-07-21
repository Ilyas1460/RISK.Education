using Education.Application.Topics.CreateTopic;
using Education.Application.Topics.DeleteTopic;
using Education.Application.Topics.GetAllTopics;
using Education.Application.Topics.GetTopic;
using Education.Application.Topics.UpdateTopic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TopicsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTopics(CancellationToken cancellationToken)
    {
        var query = new GetAllTopicsQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTopicById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTopicQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTopic([FromBody] CreateTopicCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTopic(int id, [FromBody] UpdateTopicCommand command, CancellationToken cancellationToken)
    {
        command.TopicId = id;
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id}")]
public async Task<IActionResult> DeleteTopic(int id, CancellationToken cancellationToken)
{
    var result = await _mediator.Send(new DeleteTopicCommand(id), cancellationToken);
    return Ok(new { message = $"Topic with Id {result.Id} deleted successfully." });
}

}
