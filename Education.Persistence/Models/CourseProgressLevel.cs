namespace Education.Persistence.Models;

public partial class CourseProgressLevel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Order { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CourseProgressConfiguration> CourseProgressConfigurations { get; set; } = new List<CourseProgressConfiguration>();
}
