using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Persistence.Contents;

public class Article : BaseEntity
{
    public string Slug { get; set; } = null!;

    public string? CoverImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime PublishedDate { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<ArticleTranslation> ArticleTranslations { get; set; } = new List<ArticleTranslation>();

    public virtual Category? Category { get; set; }
}
