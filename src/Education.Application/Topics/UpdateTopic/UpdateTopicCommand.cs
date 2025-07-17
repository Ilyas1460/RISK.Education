using MediatR;

namespace Education.Application.Topics.UpdateTopic;

public sealed record UpdateTopicCommand : IRequest<UpdateTopicCommandResponse>
{
    public int TopicId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? OrderInCourse { get; set; }
    public int? CourseId { get; set; }
}
