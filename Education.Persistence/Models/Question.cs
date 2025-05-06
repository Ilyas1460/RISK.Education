namespace Education.Persistence.Models;

public partial class Question
{
    public int Id { get; set; }

    public string Question1 { get; set; } = null!;

    public string AnswerExplanation { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int Level { get; set; }

    public bool IsActive { get; set; }

    public int QuestionType { get; set; }

    public string? AudioUrl { get; set; }

    public bool IsFree { get; set; }

    public virtual ICollection<LessonQuizQuestionLink> LessonQuizQuestionLinks { get; set; } = new List<LessonQuizQuestionLink>();

    public virtual ICollection<PublicQuestionAnswer> PublicQuestionAnswers { get; set; } = new List<PublicQuestionAnswer>();

    public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();

    public virtual ICollection<QuestionImage> QuestionImages { get; set; } = new List<QuestionImage>();

    public virtual ICollection<QuestionLessonLink> QuestionLessonLinks { get; set; } = new List<QuestionLessonLink>();

    public virtual ICollection<QuestionReview> QuestionReviews { get; set; } = new List<QuestionReview>();

    public virtual ICollection<RelatedQuestionLink> RelatedQuestionLinks { get; set; } = new List<RelatedQuestionLink>();

    public virtual ICollection<TestExamQuestionLink> TestExamQuestionLinks { get; set; } = new List<TestExamQuestionLink>();

    public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; } = new List<UserQuestionAnswer>();
}
