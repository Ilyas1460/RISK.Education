using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Persistence.Contents;

public class Faq : BaseEntity
{
    public string Question { get; private set; }

    public string? ShortContent { get; private set; }

    public string Content { get; private set; }

    public bool IsActive { get; private set; }

    public int? CategoryId { get; private set; }

    public int Order { get; private set; }

    public bool ShowOnMain { get; private set; }

    public string? MetaDescription { get; private set; }

    public string? MetaKeywords { get; private set; }

    public string? MetaTitle { get; private set; }

    public string Slug { get; private set; }

    public virtual Category? Category { get; private set; }
}
