using Education.Persistence.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Orders;

public class OrderDetailConfiguration : SoftDeleteEntityConfiguration<OrderDetail>
{
    protected override void ConfigureEntity(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("order_details");

        builder.Property(e => e.CourseAccessType).IsRequired();
        builder.Property(e => e.CourseId).IsRequired(false);
        builder.Property(e => e.OrderId).IsRequired(false);
        builder.Property(e => e.Price).IsRequired(false);
        builder.Property(e => e.SubscriptionPlanId).IsRequired(false);

        builder.HasOne(d => d.Course)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Order)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.SubscriptionPlan)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(d => d.SubscriptionPlanId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
