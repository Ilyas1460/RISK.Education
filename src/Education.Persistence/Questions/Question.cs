using Education.Persistence.Abstractions;
using Education.Persistence.Lessons;
using Education.Persistence.TestExams;

namespace Education.Persistence.Questions;

public class Question : BaseEntity
{
    public string Question1 { get; private set; } = null!;

    public string AnswerExplanation { get; private set; } = null!;

    public int Level { get; private set; }

    public bool IsActive { get; private set; }

    public int QuestionType { get; private set; }

    public string? AudioUrl { get; private set; }

    public bool IsFree { get; private set; }

    public virtual ICollection<LessonQuizQuestionLink> LessonQuizQuestionLinks { get; private set; } = new List<LessonQuizQuestionLink>();

    public virtual ICollection<PublicQuestionAnswer> PublicQuestionAnswers { get; private set; } = new List<PublicQuestionAnswer>();

    public virtual ICollection<QuestionAnswer> QuestionAnswers { get; private set; } = new List<QuestionAnswer>();

    public virtual ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

    public virtual ICollection<QuestionLessonLink> QuestionLessonLinks { get; private set; } = new List<QuestionLessonLink>();

    public virtual ICollection<QuestionReview> QuestionReviews { get; private set; } = new List<QuestionReview>();

    public virtual ICollection<RelatedQuestionLink> RelatedQuestionLinks { get; private set; } = new List<RelatedQuestionLink>();

    public virtual ICollection<TestExamQuestionLink> TestExamQuestionLinks { get; private set; } = new List<TestExamQuestionLink>();

    public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; private set; } = new List<UserQuestionAnswer>();
}
