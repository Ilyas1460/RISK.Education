using Education.Persistence.Abstractions;
using Education.Persistence.Answers;
using Education.Persistence.Courses;
using Education.Persistence.Quizzes;

namespace Education.Persistence.Questions;

public sealed class Question : BaseEntity
{
    public string Content { get; private set; }
    public QuestionType Type { get; private set; }
    public int CourseId { get; private set; }

    public Course Course { get; set; }

    public List<Answer> Answers { get; set; }
    public List<Quiz> Quizzes { get; set; }

    private Question(string content, QuestionType type, int courseId)
    {
        Content = content;
        Type = type;
        CourseId = courseId;
    }

    public static Question Create(string content, QuestionType type, int courseId)
    {
        return new Question(content, type, courseId);
    }
}
