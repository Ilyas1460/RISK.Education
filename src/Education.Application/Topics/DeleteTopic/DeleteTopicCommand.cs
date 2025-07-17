using MediatR;

namespace Education.Application.Topics.DeleteTopic;

public record DeleteTopicCommand(int Id) : IRequest<DeleteTopicCommandResponse>;
