using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Persistence.Contents;

public class Faq : BaseEntity
{
    public string Question { get; set; }

    public string? ShortContent { get; set; }

    public string Content { get; set; }

    public bool IsActive { get; set; }

    public int? CategoryId { get; set; }

    public int Order { get; set; }

    public bool ShowOnMain { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaTitle { get; set; }

    public string Slug { get; set; }

    public virtual Category? Category { get; set; }
}
