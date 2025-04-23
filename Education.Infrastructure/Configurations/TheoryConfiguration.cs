using Education.Persistence.Theories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal sealed class TheoryConfiguration : SoftDeleteEntityConfiguration<Theory>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Theory> builder)
    {
        builder.ToTable("theories",
            tb => tb.HasCheckConstraint("CK_Theory_OrderNumber_Positive", "\"order_number\" > 0"));

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired();

        builder.Property(t => t.Content)
            .IsRequired();

        builder.Property(t => t.OrderNumber)
            .IsRequired();
    }
}
