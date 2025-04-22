using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Categories;

public class Category : BaseEntity
{
    public int CategoryId { get; init; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public List<Course> Courses { get; set; }

    public Category(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public void UpdateTitle(string title) => Title = title;

    public void UpdateDescription(string description) => Description = description;
}
