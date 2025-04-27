using Education.Persistence.Abstractions;
using Education.Persistence.Answers;
using Education.Persistence.Categories;
using Education.Persistence.Courses;
using Education.Persistence.Languages;
using Education.Persistence.Questions;
using Education.Persistence.Quizzes;
using Education.Persistence.Theories;
using Education.Persistence.Topics;
using Education.Persistence.Videos;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Theory> Theories { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

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
