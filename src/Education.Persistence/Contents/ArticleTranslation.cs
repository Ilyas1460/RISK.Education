using Education.Persistence.Abstractions;
using Education.Persistence.Languages;

namespace Education.Persistence.Contents;

public class ArticleTranslation : BaseEntity
{
    public string Title { get; private set; } = null!;

    public string Content { get; private set; } = null!;

    public string? ShortContent { get; private set; }

    public string? MetaTitle { get; private set; }

    public string? MetaKeywords { get; private set; }

    public string? MetaDescription { get; private set; }

    public int? LanguageId { get; private set; }

    public int? ArticleId { get; private set; }

    public virtual Article? Article { get; private set; }

    public virtual Language? Language { get; private set; }
}
