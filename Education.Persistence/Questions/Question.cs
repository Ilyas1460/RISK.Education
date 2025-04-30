using Education.Persistence.Abstractions;
using Education.Persistence.Answers;
using Education.Persistence.Courses;
using Education.Persistence.Quizzes;

namespace Education.Persistence.Questions;

public class Question : BaseEntity
{
    public string Content { get; private set; }
    public QuestionType Type { get; private set; }
    public int CourseId { get; private set; }

    public virtual Course Course { get; set; }

    public virtual List<Answer> Answers { get; set; }
    public virtual List<Quiz> Quizzes { get; set; }

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
