using Education.Persistence.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Orders;

public class PriceConfiguration : SoftDeleteEntityConfiguration<Price>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Price> builder)
    {
        builder.ToTable("prices");

        builder.Property(e => e.CourseId).IsRequired(false);
        builder.Property(e => e.Discount).IsRequired();
        builder.Property(e => e.OriginalPrice).IsRequired();

        builder.HasOne(d => d.Course)
            .WithMany(p => p.Prices)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
