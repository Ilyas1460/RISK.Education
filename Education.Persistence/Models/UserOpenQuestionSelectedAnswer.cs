namespace Education.Persistence.Models;

public partial class UserOpenQuestionSelectedAnswer
{
    public int Id { get; set; }

    public int? UserQuestionAnswerId { get; set; }

    public string Answer { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; set; }
}
