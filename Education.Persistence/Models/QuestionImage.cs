namespace Education.Persistence.Models;

public partial class QuestionImage
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? ImageAlt { get; set; }

    public int Order { get; set; }

    public int QuestionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Question Question { get; set; } = null!;
}
