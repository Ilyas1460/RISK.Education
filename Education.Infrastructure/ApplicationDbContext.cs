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

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_admin_users");

            entity.ToTable("admin_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<AdminUserRoleLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_admin_user_role_links");

            entity.ToTable("admin_user_role_links");

            entity.HasIndex(e => e.AdminUserId, "ix_admin_user_role_links_admin_user_id");

            entity.HasIndex(e => e.CourseId, "ix_admin_user_role_links_course_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminRole).HasColumnName("admin_role");
            entity.Property(e => e.AdminUserId).HasColumnName("admin_user_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.AdminUser).WithMany(p => p.AdminUserRoleLinks)
                .HasForeignKey(d => d.AdminUserId)
                .HasConstraintName("fk_admin_user_role_links_admin_users_admin_user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.AdminUserRoleLinks)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_admin_user_role_links_courses_course_id");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_articles");

            entity.ToTable("articles");

            entity.HasIndex(e => e.CategoryId, "ix_articles_category_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CoverImageUrl).HasColumnName("cover_image_url");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.PublishedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published_date");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_articles_categories_category_id");
        });

        modelBuilder.Entity<ArticleTranslation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_article_translations");

            entity.ToTable("article_translations");

            entity.HasIndex(e => e.ArticleId, "ix_article_translations_article_id");

            entity.HasIndex(e => e.LanguageId, "ix_article_translations_language_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.MetaDescription).HasColumnName("meta_description");
            entity.Property(e => e.MetaKeywords).HasColumnName("meta_keywords");
            entity.Property(e => e.MetaTitle).HasColumnName("meta_title");
            entity.Property(e => e.ShortContent).HasColumnName("short_content");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleTranslations)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("fk_article_translations_articles_article_id");

            entity.HasOne(d => d.Language).WithMany(p => p.ArticleTranslations)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("fk_article_translations_languages_language_id");
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_asp_net_user_claims");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClaimType).HasColumnName("claim_type");
            entity.Property(e => e.ClaimValue).HasColumnName("claim_value");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("pk_asp_net_user_logins");

            entity.Property(e => e.LoginProvider).HasColumnName("login_provider");
            entity.Property(e => e.ProviderKey).HasColumnName("provider_key");
            entity.Property(e => e.ProviderDisplayName).HasColumnName("provider_display_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("pk_asp_net_user_roles");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("pk_asp_net_user_tokens");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LoginProvider).HasColumnName("login_provider");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<ContactUsRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_contact_us_requests");

            entity.ToTable("contact_us_requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_courses");

            entity.ToTable("courses");

            entity.HasIndex(e => e.CategoryId, "ix_courses_category_id");

            entity.HasIndex(e => e.LanguageId, "ix_courses_language_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.QuestionAnswerCount).HasColumnName("question_answer_count");
            entity.Property(e => e.ShortDescription).HasColumnName("short_description");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_courses_categories_category_id");

            entity.HasOne(d => d.Language).WithMany(p => p.Courses)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("fk_courses_languages_language_id");
        });

        modelBuilder.Entity<CourseProgressConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_course_progress_configuration");

            entity.ToTable("course_progress_configuration");

            entity.HasIndex(e => e.LevelId, "ix_course_progress_configuration_level_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Component).HasColumnName("component");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LevelId).HasColumnName("level_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Level).WithMany(p => p.CourseProgressConfigurations)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_course_progress_configuration_course_progress_level_level_id");
        });

        modelBuilder.Entity<CourseProgressLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_course_progress_level");

            entity.ToTable("course_progress_level");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<CourseSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("course_summary");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LanguageCode).HasColumnName("language_code");
            entity.Property(e => e.QuestionCount).HasColumnName("question_count");
            entity.Property(e => e.TestExamCount).HasColumnName("test_exam_count");
            entity.Property(e => e.TopicCount).HasColumnName("topic_count");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_faqs");

            entity.ToTable("faqs");

            entity.HasIndex(e => e.CategoryId, "ix_faqs_category_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MetaDescription).HasColumnName("meta_description");
            entity.Property(e => e.MetaKeywords).HasColumnName("meta_keywords");
            entity.Property(e => e.MetaTitle).HasColumnName("meta_title");
            entity.Property(e => e.Order)
                .HasDefaultValue(0)
                .HasColumnName("order");
            entity.Property(e => e.Question).HasColumnName("question");
            entity.Property(e => e.ShortContent).HasColumnName("short_content");
            entity.Property(e => e.ShowOnMain)
                .HasDefaultValue(false)
                .HasColumnName("show_on_main");
            entity.Property(e => e.Slug)
                .HasDefaultValueSql("''::text")
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Category).WithMany(p => p.Faqs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_faqs_categories_category_id");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_languages");

            entity.ToTable("languages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lessons");

            entity.ToTable("lessons");

            entity.HasIndex(e => e.TopicId, "ix_lessons_topic_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OrderInTopic).HasColumnName("order_in_topic");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Topic).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("fk_lessons_topics_topic_id");
        });

        modelBuilder.Entity<LessonQuizCompletion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_quiz_completions");

            entity.ToTable("lesson_quiz_completions");

            entity.HasIndex(e => e.LessonQuizId, "ix_lesson_quiz_completions_lesson_quiz_id");

            entity.HasIndex(e => e.UserId, "ix_lesson_quiz_completions_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonQuizId).HasColumnName("lesson_quiz_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.LessonQuiz).WithMany(p => p.LessonQuizCompletions)
                .HasForeignKey(d => d.LessonQuizId)
                .HasConstraintName("fk_lesson_quiz_completions_lesson_quizes_lesson_quiz_id");

            entity.HasOne(d => d.User).WithMany(p => p.LessonQuizCompletions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_lesson_quiz_completions_users_user_id");
        });

        modelBuilder.Entity<LessonQuizLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_quiz_links");

            entity.ToTable("lesson_quiz_links");

            entity.HasIndex(e => e.LessonId, "ix_lesson_quiz_links_lesson_id");

            entity.HasIndex(e => e.LessonQuizId, "ix_lesson_quiz_links_lesson_quiz_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.LessonQuizId).HasColumnName("lesson_quiz_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonQuizLinks)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("fk_lesson_quiz_links_lessons_lesson_id");

            entity.HasOne(d => d.LessonQuiz).WithMany(p => p.LessonQuizLinks)
                .HasForeignKey(d => d.LessonQuizId)
                .HasConstraintName("fk_lesson_quiz_links_lesson_quizes_lesson_quiz_id");
        });

        modelBuilder.Entity<LessonQuizQuestionLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_quiz_question_links");

            entity.ToTable("lesson_quiz_question_links");

            entity.HasIndex(e => e.LessonQuizId, "ix_lesson_quiz_question_links_lesson_quiz_id");

            entity.HasIndex(e => e.QuestionId, "ix_lesson_quiz_question_links_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonQuizId).HasColumnName("lesson_quiz_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.LessonQuiz).WithMany(p => p.LessonQuizQuestionLinks)
                .HasForeignKey(d => d.LessonQuizId)
                .HasConstraintName("fk_lesson_quiz_question_links_lesson_quizes_lesson_quiz_id");

            entity.HasOne(d => d.Question).WithMany(p => p.LessonQuizQuestionLinks)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_lesson_quiz_question_links_questions_question_id");
        });

        modelBuilder.Entity<LessonQuizUserQuestionAnswerLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_quiz_user_question_answer_links");

            entity.ToTable("lesson_quiz_user_question_answer_links");

            entity.HasIndex(e => e.LessonQuizId, "ix_lesson_quiz_user_question_answer_links_lesson_quiz_id");

            entity.HasIndex(e => e.UserQuestionAnswerId, "ix_lesson_quiz_user_question_answer_links_user_question_answer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonQuizId).HasColumnName("lesson_quiz_id");
            entity.Property(e => e.LessonQuizPassageToken).HasColumnName("lesson_quiz_passage_token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserQuestionAnswerId).HasColumnName("user_question_answer_id");

            entity.HasOne(d => d.LessonQuiz).WithMany(p => p.LessonQuizUserQuestionAnswerLinks)
                .HasForeignKey(d => d.LessonQuizId)
                .HasConstraintName("fk_lesson_quiz_user_question_answer_links_lesson_quizes_lesson");

            entity.HasOne(d => d.UserQuestionAnswer).WithMany(p => p.LessonQuizUserQuestionAnswerLinks)
                .HasForeignKey(d => d.UserQuestionAnswerId)
                .HasConstraintName("fk_lesson_quiz_user_question_answer_links_user_question_answer");
        });

        modelBuilder.Entity<LessonQuiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_quizes");

            entity.ToTable("lesson_quizes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsFree)
                .HasDefaultValue(false)
                .HasColumnName("is_free");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<LessonTheory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_theories");

            entity.ToTable("lesson_theories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsFree)
                .HasDefaultValue(false)
                .HasColumnName("is_free");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<LessonTheoryCompletion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_theory_completions");

            entity.ToTable("lesson_theory_completions");

            entity.HasIndex(e => e.LessonTheoryId, "ix_lesson_theory_completions_lesson_theory_id");

            entity.HasIndex(e => e.UserId, "ix_lesson_theory_completions_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonTheoryId).HasColumnName("lesson_theory_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.LessonTheory).WithMany(p => p.LessonTheoryCompletions)
                .HasForeignKey(d => d.LessonTheoryId)
                .HasConstraintName("fk_lesson_theory_completions_lesson_theories_lesson_theory_id");

            entity.HasOne(d => d.User).WithMany(p => p.LessonTheoryCompletions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_lesson_theory_completions_users_user_id");
        });

        modelBuilder.Entity<LessonTheoryLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_theory_links");

            entity.ToTable("lesson_theory_links");

            entity.HasIndex(e => e.LessonId, "ix_lesson_theory_links_lesson_id");

            entity.HasIndex(e => e.LessonTheoryId, "ix_lesson_theory_links_lesson_theory_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.LessonTheoryId).HasColumnName("lesson_theory_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonTheoryLinks)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("fk_lesson_theory_links_lessons_lesson_id");

            entity.HasOne(d => d.LessonTheory).WithMany(p => p.LessonTheoryLinks)
                .HasForeignKey(d => d.LessonTheoryId)
                .HasConstraintName("fk_lesson_theory_links_lesson_theories_lesson_theory_id");
        });

        modelBuilder.Entity<LessonVideo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_videos");

            entity.ToTable("lesson_videos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsFree)
                .HasDefaultValue(false)
                .HasColumnName("is_free");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Url).HasColumnName("url");
        });

        modelBuilder.Entity<LessonVideoCompletion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_video_completions");

            entity.ToTable("lesson_video_completions");

            entity.HasIndex(e => e.LessonVideoId, "ix_lesson_video_completions_lesson_video_id");

            entity.HasIndex(e => e.UserId, "ix_lesson_video_completions_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonVideoId).HasColumnName("lesson_video_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.LessonVideo).WithMany(p => p.LessonVideoCompletions)
                .HasForeignKey(d => d.LessonVideoId)
                .HasConstraintName("fk_lesson_video_completions_lesson_videos_lesson_video_id");

            entity.HasOne(d => d.User).WithMany(p => p.LessonVideoCompletions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_lesson_video_completions_users_user_id");
        });

        modelBuilder.Entity<LessonVideoLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_lesson_video_links");

            entity.ToTable("lesson_video_links");

            entity.HasIndex(e => e.LessonId, "ix_lesson_video_links_lesson_id");

            entity.HasIndex(e => e.LessonVideoId, "ix_lesson_video_links_lesson_video_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.LessonVideoId).HasColumnName("lesson_video_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonVideoLinks)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("fk_lesson_video_links_lessons_lesson_id");

            entity.HasOne(d => d.LessonVideo).WithMany(p => p.LessonVideoLinks)
                .HasForeignKey(d => d.LessonVideoId)
                .HasConstraintName("fk_lesson_video_links_lesson_videos_lesson_video_id");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_orders");

            entity.ToTable("orders");

            entity.HasIndex(e => e.UserId, "ix_orders_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.OrderNumber)
                .HasDefaultValueSql("''::text")
                .HasColumnName("order_number");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_orders_users_user_id");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_order_details");

            entity.ToTable("order_details");

            entity.HasIndex(e => e.CourseId, "ix_order_details_course_id");

            entity.HasIndex(e => e.OrderId, "ix_order_details_order_id");

            entity.HasIndex(e => e.SubscriptionPlanId, "ix_order_details_subscription_plan_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseAccessType).HasColumnName("course_access_type");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SubscriptionPlanId).HasColumnName("subscription_plan_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Course).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_order_details_courses_course_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_order_details_orders_order_id");

            entity.HasOne(d => d.SubscriptionPlan).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.SubscriptionPlanId)
                .HasConstraintName("fk_order_details_subscription_plans_subscription_plan_id");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_payments");

            entity.ToTable("payments");

            entity.HasIndex(e => e.OrderId, "ix_payments_order_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CallbackResponse).HasColumnName("callback_response");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_payments_orders_order_id");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_prices");

            entity.ToTable("prices");

            entity.HasIndex(e => e.CourseId, "ix_prices_course_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.OriginalPrice).HasColumnName("original_price");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Course).WithMany(p => p.Prices)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_prices_courses_course_id");
        });

        modelBuilder.Entity<PublicOpenQuestionSelectedAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_public_open_question_selected_answers");

            entity.ToTable("public_open_question_selected_answers");

            entity.HasIndex(e => e.PublicQuestionAnswerId, "ix_public_open_question_selected_answers_public_question_answe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.PublicQuestionAnswerId).HasColumnName("public_question_answer_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.PublicQuestionAnswer).WithMany(p => p.PublicOpenQuestionSelectedAnswers)
                .HasForeignKey(d => d.PublicQuestionAnswerId)
                .HasConstraintName("fk_public_open_question_selected_answers_public_question_answe");
        });

        modelBuilder.Entity<PublicQuestionAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_public_question_answers");

            entity.ToTable("public_question_answers");

            entity.HasIndex(e => e.QuestionId, "ix_public_question_answers_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnsweredCorrect)
                .HasDefaultValue(false)
                .HasColumnName("answered_correct");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.PublicId).HasColumnName("public_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Question).WithMany(p => p.PublicQuestionAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_public_question_answers_questions_question_id");
        });

        modelBuilder.Entity<PublicStandardQuestionSelectedAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_public_standard_question_selected_answers");

            entity.ToTable("public_standard_question_selected_answers");

            entity.HasIndex(e => e.PublicQuestionAnswerId, "ix_public_standard_question_selected_answers_public_question_a");

            entity.HasIndex(e => e.QuestionAnswerId, "ix_public_standard_question_selected_answers_question_answer_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.PublicQuestionAnswerId).HasColumnName("public_question_answer_id");
            entity.Property(e => e.QuestionAnswerId).HasColumnName("question_answer_id");
            entity.Property(e => e.SelectedAnswerId).HasColumnName("selected_answer_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.PublicQuestionAnswer).WithMany(p => p.PublicStandardQuestionSelectedAnswers)
                .HasForeignKey(d => d.PublicQuestionAnswerId)
                .HasConstraintName("fk_public_standard_question_selected_answers_public_question_a");

            entity.HasOne(d => d.QuestionAnswer).WithMany(p => p.PublicStandardQuestionSelectedAnswers)
                .HasForeignKey(d => d.QuestionAnswerId)
                .HasConstraintName("fk_public_standard_question_selected_answers_question_answers_");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_questions");

            entity.ToTable("questions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnswerExplanation).HasColumnName("answer_explanation");
            entity.Property(e => e.AudioUrl).HasColumnName("audio_url");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.IsFree)
                .HasDefaultValue(false)
                .HasColumnName("is_free");
            entity.Property(e => e.Level)
                .HasDefaultValue(0)
                .HasColumnName("level");
            entity.Property(e => e.Question1).HasColumnName("question1");
            entity.Property(e => e.QuestionType)
                .HasDefaultValue(0)
                .HasColumnName("question_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<QuestionAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_question_answers");

            entity.ToTable("question_answers");

            entity.HasIndex(e => e.QuestionId, "ix_question_answers_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Type)
                .HasDefaultValue(0)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_question_answers_questions_question_id");
        });

        modelBuilder.Entity<QuestionAnswerImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_question_answer_images");

            entity.ToTable("question_answer_images");

            entity.HasIndex(e => e.QuestionAnswerId, "ix_question_answer_images_question_answer_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.ImageAlt).HasColumnName("image_alt");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.QuestionAnswerId).HasColumnName("question_answer_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.QuestionAnswer).WithMany(p => p.QuestionAnswerImages)
                .HasForeignKey(d => d.QuestionAnswerId)
                .HasConstraintName("fk_question_answer_images_question_answers_question_answer_id");
        });

        modelBuilder.Entity<QuestionImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_question_images");

            entity.ToTable("question_images");

            entity.HasIndex(e => e.QuestionId, "ix_question_images_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'-infinity'::timestamp with time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.ImageAlt).HasColumnName("image_alt");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'-infinity'::timestamp with time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionImages)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_question_images_questions_question_id");
        });

        modelBuilder.Entity<QuestionLessonLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_question_lesson_links");

            entity.ToTable("question_lesson_links");

            entity.HasIndex(e => e.LessonId, "ix_question_lesson_links_lesson_id");

            entity.HasIndex(e => e.QuestionId, "ix_question_lesson_links_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Lesson).WithMany(p => p.QuestionLessonLinks)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("fk_question_lesson_links_lessons_lesson_id");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionLessonLinks)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_question_lesson_links_questions_question_id");
        });

        modelBuilder.Entity<QuestionReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_question_reviews");

            entity.ToTable("question_reviews");

            entity.HasIndex(e => e.QuestionId, "ix_question_reviews_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.QuestionBugStatus)
                .HasDefaultValue(0)
                .HasColumnName("question_bug_status");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.QuestionReviewStatus)
                .HasDefaultValue(1)
                .HasColumnName("question_review_status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionReviews)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_question_reviews_questions_question_id");
        });

        modelBuilder.Entity<RelatedQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_related_questions");

            entity.ToTable("related_questions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AudioUrl).HasColumnName("audio_url");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Question).HasColumnName("question");
            entity.Property(e => e.QuestionType).HasColumnName("question_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<RelatedQuestionLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_related_question_links");

            entity.ToTable("related_question_links");

            entity.HasIndex(e => e.QuestionId, "ix_related_question_links_question_id");

            entity.HasIndex(e => e.RelatedQuestionId, "ix_related_question_links_related_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.RelatedQuestionId).HasColumnName("related_question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Question).WithMany(p => p.RelatedQuestionLinks)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_related_question_links_questions_question_id");

            entity.HasOne(d => d.RelatedQuestion).WithMany(p => p.RelatedQuestionLinks)
                .HasForeignKey(d => d.RelatedQuestionId)
                .HasConstraintName("fk_related_question_links_related_questions_related_question_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_roles");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NormalizedName).HasColumnName("normalized_name");
        });

        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_role_claims");

            entity.ToTable("role_claims");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClaimType).HasColumnName("claim_type");
            entity.Property(e => e.ClaimValue).HasColumnName("claim_value");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_subscription_plans");

            entity.ToTable("subscription_plans");

            entity.HasIndex(e => e.CourseId, "ix_subscription_plans_course_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BasePrice).HasColumnName("base_price");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DiscountedPrice).HasColumnName("discounted_price");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.DurationType).HasColumnName("duration_type");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Course).WithMany(p => p.SubscriptionPlans)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_subscription_plans_courses_course_id");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tags");

            entity.ToTable("tags");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<TestExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_test_exams");

            entity.ToTable("test_exams");

            entity.HasIndex(e => e.CourseId, "ix_test_exams_course_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasDefaultValue(0)
                .HasColumnName("duration");
            entity.Property(e => e.ExplanationUrl).HasColumnName("explanation_url");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsFree)
                .HasDefaultValue(false)
                .HasColumnName("is_free");
            entity.Property(e => e.Level)
                .HasDefaultValue(0)
                .HasColumnName("level");
            entity.Property(e => e.Order)
                .HasDefaultValue(0)
                .HasColumnName("order");
            entity.Property(e => e.PublishDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("publish_date");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Course).WithMany(p => p.TestExams)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_test_exams_courses_course_id");
        });

        modelBuilder.Entity<TestExamHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_test_exam_history");

            entity.ToTable("test_exam_history");

            entity.HasIndex(e => e.TestExamId, "ix_test_exam_history_test_exam_id");

            entity.HasIndex(e => e.UserId, "ix_test_exam_history_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasDefaultValueSql("'-infinity'::timestamp with time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.TestExamId).HasColumnName("test_exam_id");
            entity.Property(e => e.TestExamPassageToken).HasColumnName("test_exam_passage_token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.TestExam).WithMany(p => p.TestExamHistories)
                .HasForeignKey(d => d.TestExamId)
                .HasConstraintName("fk_test_exam_history_test_exams_test_exam_id");

            entity.HasOne(d => d.User).WithMany(p => p.TestExamHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_test_exam_history_users_user_id");
        });

        modelBuilder.Entity<TestExamHistoryUserQuestionAnswerLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_test_exam_history_user_question_answer_links");

            entity.ToTable("test_exam_history_user_question_answer_links");

            entity.HasIndex(e => e.TestExamHistoryId, "ix_test_exam_history_user_question_answer_links_test_exam_hist");

            entity.HasIndex(e => e.UserQuestionAnswerId, "ix_test_exam_history_user_question_answer_links_user_question_");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.TestExamHistoryId).HasColumnName("test_exam_history_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserQuestionAnswerId).HasColumnName("user_question_answer_id");

            entity.HasOne(d => d.TestExamHistory).WithMany(p => p.TestExamHistoryUserQuestionAnswerLinks)
                .HasForeignKey(d => d.TestExamHistoryId)
                .HasConstraintName("fk_test_exam_history_user_question_answer_links_test_exam_hist");

            entity.HasOne(d => d.UserQuestionAnswer).WithMany(p => p.TestExamHistoryUserQuestionAnswerLinks)
                .HasForeignKey(d => d.UserQuestionAnswerId)
                .HasConstraintName("fk_test_exam_history_user_question_answer_links_user_question_");
        });

        modelBuilder.Entity<TestExamQuestionLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_test_exam_question_links");

            entity.ToTable("test_exam_question_links");

            entity.HasIndex(e => e.QuestionId, "ix_test_exam_question_links_question_id");

            entity.HasIndex(e => e.TestExamId, "ix_test_exam_question_links_test_exam_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.TestExamId).HasColumnName("test_exam_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Question).WithMany(p => p.TestExamQuestionLinks)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_test_exam_question_links_questions_question_id");

            entity.HasOne(d => d.TestExam).WithMany(p => p.TestExamQuestionLinks)
                .HasForeignKey(d => d.TestExamId)
                .HasConstraintName("fk_test_exam_question_links_test_exams_test_exam_id");
        });

        modelBuilder.Entity<TestExamTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_test_exam_tags");

            entity.ToTable("test_exam_tags");

            entity.HasIndex(e => e.TagId, "ix_test_exam_tags_tag_id");

            entity.HasIndex(e => e.TestExamId, "ix_test_exam_tags_test_exam_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.TestExamId).HasColumnName("test_exam_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Tag).WithMany(p => p.TestExamTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("fk_test_exam_tags_tags_tag_id");

            entity.HasOne(d => d.TestExam).WithMany(p => p.TestExamTags)
                .HasForeignKey(d => d.TestExamId)
                .HasConstraintName("fk_test_exam_tags_test_exams_test_exam_id");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_topics");

            entity.ToTable("topics");

            entity.HasIndex(e => e.CourseId, "ix_topics_course_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OrderInCourse).HasColumnName("order_in_course");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Course).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_topics_courses_course_id");
        });

        modelBuilder.Entity<TopicContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_topic_contents");

            entity.ToTable("topic_contents");

            entity.HasIndex(e => e.LessonQuizId, "ix_topic_contents_lesson_quiz_id");

            entity.HasIndex(e => e.LessonTheoryId, "ix_topic_contents_lesson_theory_id");

            entity.HasIndex(e => e.LessonVideoId, "ix_topic_contents_lesson_video_id");

            entity.HasIndex(e => e.TopicId, "ix_topic_contents_topic_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.LessonQuizId).HasColumnName("lesson_quiz_id");
            entity.Property(e => e.LessonTheoryId).HasColumnName("lesson_theory_id");
            entity.Property(e => e.LessonVideoId).HasColumnName("lesson_video_id");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.LessonQuiz).WithMany(p => p.TopicContents)
                .HasForeignKey(d => d.LessonQuizId)
                .HasConstraintName("fk_topic_contents_lesson_quizes_lesson_quiz_id");

            entity.HasOne(d => d.LessonTheory).WithMany(p => p.TopicContents)
                .HasForeignKey(d => d.LessonTheoryId)
                .HasConstraintName("fk_topic_contents_lesson_theories_lesson_theory_id");

            entity.HasOne(d => d.LessonVideo).WithMany(p => p.TopicContents)
                .HasForeignKey(d => d.LessonVideoId)
                .HasConstraintName("fk_topic_contents_lesson_videos_lesson_video_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.TopicContents)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("fk_topic_contents_topics_topic_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.ToTable("users");

            entity.HasIndex(e => e.NormalizedUserName, "uk_users_normalized_user_name").IsUnique();

            entity.HasIndex(e => e.UserName, "uk_users_user_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessFailedCount).HasColumnName("access_failed_count");
            entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LockoutEnabled).HasColumnName("lockout_enabled");
            entity.Property(e => e.LockoutEnd).HasColumnName("lockout_end");
            entity.Property(e => e.NormalizedEmail).HasColumnName("normalized_email");
            entity.Property(e => e.NormalizedUserName).HasColumnName("normalized_user_name");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            entity.Property(e => e.SecurityStamp).HasColumnName("security_stamp");
            entity.Property(e => e.TwoFactorEnabled).HasColumnName("two_factor_enabled");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName).HasColumnName("user_name");
        });

        modelBuilder.Entity<UserCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_user_courses");

            entity.ToTable("user_courses");

            entity.HasIndex(e => e.CourseId, "ix_user_courses_course_id");

            entity.HasIndex(e => e.UserId, "ix_user_courses_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseAccessType).HasColumnName("course_access_type");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.ExpireTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expire_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_user_courses_courses_course_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_courses_users_user_id");
        });

        modelBuilder.Entity<UserOpenQuestionSelectedAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_user_open_question_selected_answers");

            entity.ToTable("user_open_question_selected_answers");

            entity.HasIndex(e => e.UserQuestionAnswerId, "ix_user_open_question_selected_answers_user_question_answer_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserQuestionAnswerId).HasColumnName("user_question_answer_id");

            entity.HasOne(d => d.UserQuestionAnswer).WithMany(p => p.UserOpenQuestionSelectedAnswers)
                .HasForeignKey(d => d.UserQuestionAnswerId)
                .HasConstraintName("fk_user_open_question_selected_answers_user_question_answers_u");
        });

        modelBuilder.Entity<UserQuestionAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_user_question_answers");

            entity.ToTable("user_question_answers");

            entity.HasIndex(e => e.QuestionAnswerEntityId, "ix_user_question_answers_question_answer_entity_id");

            entity.HasIndex(e => e.QuestionId, "ix_user_question_answers_question_id");

            entity.HasIndex(e => e.UserId, "ix_user_question_answers_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnsweredCorrect).HasColumnName("answered_correct");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.QuestionAnswerEntityId).HasColumnName("question_answer_entity_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.QuestionAnswerEntity).WithMany(p => p.UserQuestionAnswers)
                .HasForeignKey(d => d.QuestionAnswerEntityId)
                .HasConstraintName("fk_user_question_answers_question_answers_question_answer_enti");

            entity.HasOne(d => d.Question).WithMany(p => p.UserQuestionAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("fk_user_question_answers_questions_question_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserQuestionAnswers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_question_answers_users_user_id");
        });

        modelBuilder.Entity<UserStandardQuestionSelectedAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_user_standard_question_selected_answers");

            entity.ToTable("user_standard_question_selected_answers");

            entity.HasIndex(e => e.UserQuestionAnswerId, "ix_user_standard_question_selected_answers_user_question_answe");

            entity.HasIndex(e => e.UserSelectedAnswerId, "ix_user_standard_question_selected_answers_user_selected_answe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserQuestionAnswerId).HasColumnName("user_question_answer_id");
            entity.Property(e => e.UserSelectedAnswerId).HasColumnName("user_selected_answer_id");

            entity.HasOne(d => d.UserQuestionAnswer).WithMany(p => p.UserStandardQuestionSelectedAnswers)
                .HasForeignKey(d => d.UserQuestionAnswerId)
                .HasConstraintName("fk_user_standard_question_selected_answers_user_question_answe");

            entity.HasOne(d => d.UserSelectedAnswer).WithMany(p => p.UserStandardQuestionSelectedAnswers)
                .HasForeignKey(d => d.UserSelectedAnswerId)
                .HasConstraintName("fk_user_standard_question_selected_answers_question_answers_us");
        });

        base.OnModelCreating(modelBuilder);
    }
}
