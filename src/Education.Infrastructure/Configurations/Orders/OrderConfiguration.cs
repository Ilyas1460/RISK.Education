using Education.Persistence.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Orders;

public class OrderConfiguration : SoftDeleteEntityConfiguration<Order>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.Property(e => e.OrderNumber).HasDefaultValueSql("''::text").IsRequired();
        builder.Property(e => e.Status).IsRequired();
        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(d => d.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
