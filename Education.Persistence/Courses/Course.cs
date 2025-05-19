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
    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public string Description { get; set; }

    public int? CategoryId { get; set; }

    public int? LanguageId { get; set; }

    public int? QuestionAnswerCount { get; set; }

    public bool IsActive { get; set; }

    public string? Slug { get; set; }

    public virtual ICollection<AdminUserRoleLink> AdminUserRoleLinks { get; set; } = new List<AdminUserRoleLink>();

    public virtual Category? Category { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<SubscriptionPlan> SubscriptionPlans { get; set; } = new List<SubscriptionPlan>();

    public virtual ICollection<TestExam> TestExams { get; set; } = new List<TestExam>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}
