using Education.Persistence.Abstractions;
using Education.Persistence.Contents;
using Education.Persistence.Courses;

namespace Education.Persistence.Categories;

public class Category : BaseEntity
{
    public string Name { get; private set; }

    public virtual List<Article> Articles { get; set; }

    public virtual List<Course> Courses { get; set; }

    public virtual List<Faq> Faqs { get; set; }

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
