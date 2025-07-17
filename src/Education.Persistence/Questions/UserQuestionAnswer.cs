using Education.Persistence.Abstractions;
using Education.Persistence.Lessons;
using Education.Persistence.TestExams;
using Education.Persistence.Users;

namespace Education.Persistence.Questions;

public class UserQuestionAnswer : BaseEntity
{
    public int? UserId { get; set; }

    public int? QuestionId { get; set; }

    public bool AnsweredCorrect { get; set; }

    public int? QuestionAnswerEntityId { get; set; }

    public virtual ICollection<LessonQuizUserQuestionAnswerLink> LessonQuizUserQuestionAnswerLinks { get; set; } = new List<LessonQuizUserQuestionAnswerLink>();

    public virtual Question? Question { get; set; }

    public virtual QuestionAnswer? QuestionAnswerEntity { get; set; }

    public virtual ICollection<TestExamHistoryUserQuestionAnswerLink> TestExamHistoryUserQuestionAnswerLinks { get; set; } = new List<TestExamHistoryUserQuestionAnswerLink>();

    public virtual User? User { get; set; }

    public virtual ICollection<UserOpenQuestionSelectedAnswer> UserOpenQuestionSelectedAnswers { get; set; } = new List<UserOpenQuestionSelectedAnswer>();

    public virtual ICollection<UserStandardQuestionSelectedAnswer> UserStandardQuestionSelectedAnswers { get; set; } = new List<UserStandardQuestionSelectedAnswer>();
}
