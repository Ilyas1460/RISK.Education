using Education.Persistence.Categories;

namespace Education.Persistence.Contents;

public class Faq
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string? ShortContent { get; set; }

    public string Content { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? CategoryId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int Order { get; set; }

    public bool ShowOnMain { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaTitle { get; set; }

    public string Slug { get; set; } = null!;

    public virtual Category? Category { get; set; }
}
