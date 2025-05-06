namespace Education.Persistence.Models;

public partial class PublicQuestionAnswer
{
    public int Id { get; set; }

    public string? PublicId { get; set; }

    public int? QuestionId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool AnsweredCorrect { get; set; }

    public virtual ICollection<PublicOpenQuestionSelectedAnswer> PublicOpenQuestionSelectedAnswers { get; set; } = new List<PublicOpenQuestionSelectedAnswer>();

    public virtual ICollection<PublicStandardQuestionSelectedAnswer> PublicStandardQuestionSelectedAnswers { get; set; } = new List<PublicStandardQuestionSelectedAnswer>();

    public virtual Question? Question { get; set; }
}
