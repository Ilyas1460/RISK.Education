using Education.Persistence.Abstractions;
using Education.Persistence.Contents;
using Education.Persistence.Courses;

namespace Education.Persistence.Categories;

public class Category : BaseEntity
{
    public string Name { get; private set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Faq> Faqs { get; set; } = new List<Faq>();

    private Category(string name)
    {
        Name = name;
    }

    protected Category()
    {
    }

    public static Category Create(string name)
    {
        return new Category(name);
    }

    public void UpdateCategory(string name)
    {
        Name = name;
    }
}
