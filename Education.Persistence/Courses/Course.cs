using Education.Persistence.Categories;
using Education.Persistence.Contents;
using Education.Persistence.Languages;
using Education.Persistence.Orders;
using Education.Persistence.TestExams;
using Education.Persistence.Users;

namespace Education.Persistence.Courses;

public class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? LanguageId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

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
