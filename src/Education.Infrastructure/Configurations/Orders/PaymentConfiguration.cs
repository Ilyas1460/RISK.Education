using Education.Persistence.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Orders;

public class PaymentConfiguration : SoftDeleteEntityConfiguration<Payment>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");

        builder.Property(e => e.Amount).IsRequired();
        builder.Property(e => e.CallbackResponse).IsRequired(false);
        builder.Property(e => e.OrderId).IsRequired(false);

        builder.HasOne(d => d.Order)
            .WithMany(p => p.Payments)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
