using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Contents;

public class ArticleTranslationConfiguration : SoftDeleteEntityConfiguration<ArticleTranslation>
{
    protected override void ConfigureEntity(EntityTypeBuilder<ArticleTranslation> builder)
    {
        builder.ToTable("article_translations");

        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.Content).IsRequired();
        builder.Property(e => e.ArticleId).IsRequired(false);
        builder.Property(e => e.LanguageId).IsRequired(false);
        builder.Property(e => e.MetaDescription).IsRequired(false);
        builder.Property(e => e.MetaKeywords).IsRequired(false);
        builder.Property(e => e.MetaTitle).IsRequired(false);
        builder.Property(e => e.ShortContent).IsRequired(false);

        builder.HasOne(d => d.Article)
            .WithMany(p => p.ArticleTranslations)
            .HasForeignKey(d => d.ArticleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Language)
            .WithMany(p => p.ArticleTranslations)
            .HasForeignKey(d => d.LanguageId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
