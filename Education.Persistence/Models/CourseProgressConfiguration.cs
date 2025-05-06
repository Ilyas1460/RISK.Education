namespace Education.Persistence.Models;

public partial class CourseProgressConfiguration
{
    public int Id { get; set; }

    public int? LevelId { get; set; }

    public int Component { get; set; }

    public double Weight { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual CourseProgressLevel? Level { get; set; }
}
