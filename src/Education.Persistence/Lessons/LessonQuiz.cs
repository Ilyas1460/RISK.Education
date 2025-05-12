using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.Lessons;

public class LessonQuiz : BaseEntity
{
    public string Title { get; set; }

    public bool IsActive { get; set; }

    public bool IsFree { get; set; }

    public virtual ICollection<LessonQuizCompletion> LessonQuizCompletions { get; set; } = new List<LessonQuizCompletion>();

    public virtual ICollection<LessonQuizLink> LessonQuizLinks { get; set; } = new List<LessonQuizLink>();

    public virtual ICollection<LessonQuizQuestionLink> LessonQuizQuestionLinks { get; set; } = new List<LessonQuizQuestionLink>();

    public virtual ICollection<LessonQuizUserQuestionAnswerLink> LessonQuizUserQuestionAnswerLinks { get; set; } = new List<LessonQuizUserQuestionAnswerLink>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();

    protected LessonQuiz()
    {
    }
}
