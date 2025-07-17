using MediatR;

namespace Education.Application.Topics.CreateTopic;

public sealed record CreateTopicCommand(
    string Name,
    string? Description,
    int? OrderInCourse,
    int? CourseId) : IRequest<CreateTopicCommandResponse>;
