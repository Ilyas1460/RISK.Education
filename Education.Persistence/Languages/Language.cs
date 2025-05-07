using Education.Persistence.Contents;
using Education.Persistence.Courses;

namespace Education.Persistence.Languages;

public class Language
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ArticleTranslation> ArticleTranslations { get; set; } = new List<ArticleTranslation>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
