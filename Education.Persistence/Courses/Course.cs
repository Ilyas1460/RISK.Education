using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using Education.Persistence.Languages;
using Education.Persistence.Questions;
using Education.Persistence.Topics;

namespace Education.Persistence.Courses;

public sealed class Course : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CategoryId { get; private set; }
    public int LanguageId { get; private set; }

    public Category Category { get; set; }
    public Language Language { get; set; }

    public List<Topic> Topics { get; set; }
    public List<Question> Questions { get; set; }

    private Course(string title, string description, int categoryId, int languageId)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;
        LanguageId = languageId;
    }

    public static Course Create(string title, string description, int categoryId, int languageId)
    {
        return new Course(title, description, categoryId, languageId);
    }

    public void UpdateTitle(string title) => Title = title;

    public void UpdateDescription(string description) => Description = description;

    public void UpdateCategoryId(int categoryId) => CategoryId = categoryId;

    public void UpdateLanguageId(int languageId) => LanguageId = languageId;
}
