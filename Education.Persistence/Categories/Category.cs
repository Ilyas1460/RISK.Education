using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Categories;

public sealed class Category : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }

    public List<Course> Courses { get; set; }

    private Category(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public static Category Create(string title, string description)
    {
        return new Category(title, description);
    }

    public void UpdateTitle(string title) => Title = title;

    public void UpdateDescription(string description) => Description = description;
}
