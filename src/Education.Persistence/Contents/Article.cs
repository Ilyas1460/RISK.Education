using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Persistence.Contents;

public class Article : BaseEntity
{
    public string Slug { get; private set; } = null!;

    public string? CoverImageUrl { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime PublishedDate { get; private set; }

    public int? CategoryId { get; private set; }

    public virtual ICollection<ArticleTranslation> ArticleTranslations { get; private set; } = new List<ArticleTranslation>();

    public virtual Category? Category { get; private set; }
}
