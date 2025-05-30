namespace Education.Persistence.Courses;

public class CourseSummary
{
    public int? CourseId { get; private set; }

    public bool? IsActive { get; private set; }

    public string? LanguageCode { get; private set; }

    public long? TopicCount { get; private set; }

    public long? QuestionCount { get; private set; }

    public long? TestExamCount { get; private set; }
}
