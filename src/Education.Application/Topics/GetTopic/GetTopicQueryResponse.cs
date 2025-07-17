namespace Education.Application.Topics.GetTopic;

public record GetTopicQueryResponse(
    int Id,
    string Name,
    string? Description,
    int? OrderInCourse,   
    int? CourseId,        
    DateTime CreatedAt,
    DateTime? UpdatedAt);
