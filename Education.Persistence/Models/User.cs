namespace Education.Persistence.Models;

public partial class User
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<LessonQuizCompletion> LessonQuizCompletions { get; set; } = new List<LessonQuizCompletion>();

    public virtual ICollection<LessonTheoryCompletion> LessonTheoryCompletions { get; set; } = new List<LessonTheoryCompletion>();

    public virtual ICollection<LessonVideoCompletion> LessonVideoCompletions { get; set; } = new List<LessonVideoCompletion>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<TestExamHistory> TestExamHistories { get; set; } = new List<TestExamHistory>();

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();

    public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; } = new List<UserQuestionAnswer>();
}
