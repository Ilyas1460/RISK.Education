namespace Education.Persistence.Courses;

public class CourseSummary
{
    public int? CourseId { get; set; }

    public bool? IsActive { get; set; }

    public string? LanguageCode { get; set; }

    public long? TopicCount { get; set; }

    public long? QuestionCount { get; set; }

    public long? TestExamCount { get; set; }
}
