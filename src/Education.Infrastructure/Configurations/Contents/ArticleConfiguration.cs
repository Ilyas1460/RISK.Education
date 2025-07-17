using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Contents;

public class ArticleConfiguration : SoftDeleteEntityConfiguration<Article>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("articles");

        builder.Property(e => e.CategoryId).IsRequired(false);
        builder.Property(e => e.CoverImageUrl).IsRequired(false);
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.PublishedDate).IsRequired();
        builder.Property(e => e.Slug).IsRequired();

        builder.HasOne(d => d.Category)
            .WithMany(p => p.Articles)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
