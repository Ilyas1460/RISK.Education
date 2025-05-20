using Education.Persistence.Abstractions;
using Education.Persistence.Languages;

namespace Education.Persistence.Contents;

public class ArticleTranslation : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? ShortContent { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaDescription { get; set; }

    public int? LanguageId { get; set; }

    public int? ArticleId { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Language? Language { get; set; }
}
