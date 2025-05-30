using Education.Persistence.Abstractions;
using Education.Persistence.Lessons;
using Education.Persistence.TestExams;
using Education.Persistence.Users;

namespace Education.Persistence.Questions;

public class UserQuestionAnswer : BaseEntity
{
    public int? UserId { get; private set; }

    public int? QuestionId { get; private set; }

    public bool AnsweredCorrect { get; private set; }

    public int? QuestionAnswerEntityId { get; private set; }

    public virtual ICollection<LessonQuizUserQuestionAnswerLink> LessonQuizUserQuestionAnswerLinks { get; private set; } = new List<LessonQuizUserQuestionAnswerLink>();

    public virtual Question? Question { get; private set; }

    public virtual QuestionAnswer? QuestionAnswerEntity { get; private set; }

    public virtual ICollection<TestExamHistoryUserQuestionAnswerLink> TestExamHistoryUserQuestionAnswerLinks { get; private set; } = new List<TestExamHistoryUserQuestionAnswerLink>();

    public virtual User? User { get; private set; }

    public virtual ICollection<UserOpenQuestionSelectedAnswer> UserOpenQuestionSelectedAnswers { get; private set; } = new List<UserOpenQuestionSelectedAnswer>();

    public virtual ICollection<UserStandardQuestionSelectedAnswer> UserStandardQuestionSelectedAnswers { get; private set; } = new List<UserStandardQuestionSelectedAnswer>();
}
