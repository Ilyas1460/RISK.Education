using Education.Infrastructure.Interceptors;
using Education.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .AddInterceptors(new AuditableEntityInterceptor())
            .UseSnakeCaseNamingConvention();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}