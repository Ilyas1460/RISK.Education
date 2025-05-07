using Education.Persistence.Categories;

namespace Education.Persistence.Contents;

public class Article
{
    public int Id { get; set; }

    public string Slug { get; set; } = null!;

    public string? CoverImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime PublishedDate { get; set; }

    public int? CategoryId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ArticleTranslation> ArticleTranslations { get; set; } = new List<ArticleTranslation>();

    public virtual Category? Category { get; set; }
}
