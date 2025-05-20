using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Courses;

public class SubscriptionPlanConfiguration : SoftDeleteEntityConfiguration<SubscriptionPlan>
{
    protected override void ConfigureEntity(EntityTypeBuilder<SubscriptionPlan> builder)
    {
        builder.ToTable("subscription_plans");

        builder.Property(e => e.BasePrice).IsRequired();
        builder.Property(e => e.CourseId).IsRequired(false);
        builder.Property(e => e.DiscountedPrice).IsRequired();
        builder.Property(e => e.Duration).IsRequired();
        builder.Property(e => e.DurationType).IsRequired();
        builder.Property(e => e.Name).IsRequired();

        builder.HasOne(d => d.Course)
            .WithMany(p => p.SubscriptionPlans)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
