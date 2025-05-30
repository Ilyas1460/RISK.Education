using Education.Persistence.Abstractions;
using Education.Persistence.Contents;
using Education.Persistence.Courses;

namespace Education.Persistence.Languages;

public class Language : BaseEntity
{
    public string Code { get; private set; } = null!;

    public virtual ICollection<ArticleTranslation> ArticleTranslations { get; private set; } = new List<ArticleTranslation>();

    public virtual ICollection<Course> Courses { get; private set; } = new List<Course>();

    private Language(string code)
    {
        Code = code;
    }

    protected Language()
    {
    }

    public static Language Create(string code)
    {
        return new Language(code);
    }

    public void UpdateLanguage(string code)
    {
        Code = code;
    }
}
