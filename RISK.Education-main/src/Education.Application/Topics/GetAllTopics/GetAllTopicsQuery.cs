using MediatR;

namespace Education.Application.Topics.GetAllTopics;

public sealed record GetAllTopicsQuery : IRequest<GetAllTopicsQueryResponse>;
