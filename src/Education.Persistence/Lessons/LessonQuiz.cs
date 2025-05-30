using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.Lessons;

public class LessonQuiz : BaseEntity
{
    public string Title { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsFree { get; private set; }

    public virtual ICollection<LessonQuizCompletion> LessonQuizCompletions { get; private set; } = new List<LessonQuizCompletion>();

    public virtual ICollection<LessonQuizLink> LessonQuizLinks { get; private set; } = new List<LessonQuizLink>();

    public virtual ICollection<LessonQuizQuestionLink> LessonQuizQuestionLinks { get; private set; } = new List<LessonQuizQuestionLink>();

    public virtual ICollection<LessonQuizUserQuestionAnswerLink> LessonQuizUserQuestionAnswerLinks { get; private set; } = new List<LessonQuizUserQuestionAnswerLink>();

    public virtual ICollection<TopicContent> TopicContents { get; private set; } = new List<TopicContent>();

    protected LessonQuiz()
    {
    }
}
