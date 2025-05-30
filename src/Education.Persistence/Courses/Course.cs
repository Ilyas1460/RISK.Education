using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using Education.Persistence.Contents;
using Education.Persistence.Languages;
using Education.Persistence.Orders;
using Education.Persistence.TestExams;
using Education.Persistence.Users;

namespace Education.Persistence.Courses;

public class Course : BaseEntity
{
    public string Name { get; private set; }

    public string? ShortDescription { get; private set; }

    public string? Description { get; private set; }

    public int? CategoryId { get; private set; }

    public int? LanguageId { get; private set; }

    public int? QuestionAnswerCount { get; private set; }

    public bool IsActive { get; private set; }

    public string? Slug { get; private set; }

    public virtual ICollection<AdminUserRoleLink> AdminUserRoleLinks { get; private set; } = new List<AdminUserRoleLink>();

    public virtual Category? Category { get; private set; }

    public virtual Language? Language { get; private set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; private set; } = new List<OrderDetail>();

    public virtual ICollection<Price> Prices { get; private set; } = new List<Price>();

    public virtual ICollection<SubscriptionPlan> SubscriptionPlans { get; private set; } = new List<SubscriptionPlan>();

    public virtual ICollection<TestExam> TestExams { get; private set; } = new List<TestExam>();

    public virtual ICollection<Topic> Topics { get; private set; } = new List<Topic>();

    public virtual ICollection<UserCourse> UserCourses { get; private set; } = new List<UserCourse>();

    protected Course()
    {
    }

    private Course(string name, string? shortDescription, string? description, int? categoryId, int? languageId,
        int? questionAnswerCount, bool isActive, string? slug)
    {
        Name = name;
        ShortDescription = shortDescription;
        Description = description;
        CategoryId = categoryId;
        LanguageId = languageId;
        QuestionAnswerCount = questionAnswerCount;
        IsActive = isActive;
        Slug = slug;
    }

    public static Course Create(string name, string? shortDescription, string? description, int? categoryId,
        int? languageId, int? questionAnswerCount, bool isActive, string? slug)
    {
        return new Course(name, shortDescription, description, categoryId, languageId, questionAnswerCount, isActive,
            slug);
    }

    public void UpdateCourse(string name, string? shortDescription, string? description, int? categoryId, int? languageId,
        int? questionAnswerCount, bool isActive, string? slug)
    {
        Name = name;
        ShortDescription = shortDescription;
        Description = description;
        CategoryId = categoryId;
        LanguageId = languageId;
        QuestionAnswerCount = questionAnswerCount;
        IsActive = isActive;
        Slug = slug;
    }
}
