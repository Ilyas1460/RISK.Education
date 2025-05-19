using Education.Persistence.Abstractions;
using Education.Persistence.AspNetUser;
using Education.Persistence.Categories;
using Education.Persistence.Contents;
using Education.Persistence.Courses;
using Education.Persistence.Lessons;
using Education.Persistence.Orders;
using Education.Persistence.Questions;
using Education.Persistence.TestExams;
using Education.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Course = Education.Persistence.Courses.Course;
using Language = Education.Persistence.Languages.Language;
using Question = Education.Persistence.Questions.Question;
using Topic = Education.Persistence.Contents.Topic;

namespace Education.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<AdminUser> AdminUsers { get; set; }
    public DbSet<AdminUserRoleLink> AdminUserRoleLinks { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleTranslation> ArticleTranslations { get; set; }
    public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
    public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
    public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
    public DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ContactUsRequest> ContactUsRequests { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseProgressConfiguration> CourseProgressConfigurations { get; set; }
    public DbSet<CourseProgressLevel> CourseProgressLevels { get; set; }
    public DbSet<CourseSummary> CourseSummaries { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonQuizCompletion> LessonQuizCompletions { get; set; }
    public DbSet<LessonQuizLink> LessonQuizLinks { get; set; }
    public DbSet<LessonQuizQuestionLink> LessonQuizQuestionLinks { get; set; }
    public DbSet<LessonQuizUserQuestionAnswerLink> LessonQuizUserQuestionAnswerLinks { get; set; }
    public DbSet<LessonQuiz> LessonQuizzes { get; set; }
    public DbSet<LessonTheory> LessonTheories { get; set; }
    public DbSet<LessonTheoryCompletion> LessonTheoryCompletions { get; set; }
    public DbSet<LessonTheoryLink> LessonTheoryLinks { get; set; }
    public DbSet<LessonVideo> LessonVideos { get; set; }
    public DbSet<LessonVideoCompletion> LessonVideoCompletions { get; set; }
    public DbSet<LessonVideoLink> LessonVideoLinks { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<PublicOpenQuestionSelectedAnswer> PublicOpenQuestionSelectedAnswers { get; set; }
    public DbSet<PublicQuestionAnswer> PublicQuestionAnswers { get; set; }
    public DbSet<PublicStandardQuestionSelectedAnswer> PublicStandardQuestionSelectedAnswers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<QuestionAnswerImage> QuestionAnswerImages { get; set; }
    public DbSet<QuestionImage> QuestionImages { get; set; }
    public DbSet<QuestionLessonLink> QuestionLessonLinks { get; set; }
    public DbSet<QuestionReview> QuestionReviews { get; set; }
    public DbSet<RelatedQuestion> RelatedQuestions { get; set; }
    public DbSet<RelatedQuestionLink> RelatedQuestionLinks { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TestExam> TestExams { get; set; }
    public DbSet<TestExamHistory> TestExamHistories { get; set; }
    public DbSet<TestExamHistoryUserQuestionAnswerLink> TestExamHistoryUserQuestionAnswerLinks { get; set; }
    public DbSet<TestExamQuestionLink> TestExamQuestionLinks { get; set; }
    public DbSet<TestExamTag> TestExamTags { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<TopicContent> TopicContents { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public DbSet<UserOpenQuestionSelectedAnswer> UserOpenQuestionSelectedAnswers { get; set; }
    public DbSet<UserQuestionAnswer> UserQuestionAnswers { get; set; }
    public DbSet<UserStandardQuestionSelectedAnswer> UserStandardQuestionSelectedAnswers { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
