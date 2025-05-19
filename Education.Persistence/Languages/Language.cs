using Education.Persistence.Abstractions;
using Education.Persistence.Contents;
using Education.Persistence.Courses;

namespace Education.Persistence.Languages;

public class Language : BaseEntity
{
    public string Code { get; set; } = null!;

    public virtual ICollection<ArticleTranslation> ArticleTranslations { get; set; } = new List<ArticleTranslation>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    private Language(string code)
    {
        Code = code;
    }

    protected Language()
    {
    }
}
