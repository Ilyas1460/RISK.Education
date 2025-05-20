using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Contents;

public class FaqConfiguration : SoftDeleteEntityConfiguration<Faq>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Faq> builder)
    {
        builder.ToTable("faqs");

        builder.Property(e => e.Content).IsRequired();
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.MetaDescription).IsRequired(false);
        builder.Property(e => e.MetaKeywords).IsRequired(false);
        builder.Property(e => e.MetaTitle).IsRequired(false);
        builder.Property(e => e.Order).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.Question).IsRequired();
        builder.Property(e => e.ShortContent).IsRequired(false);
        builder.Property(e => e.ShowOnMain).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.Slug).HasDefaultValueSql("''::text").IsRequired();

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Faqs)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
