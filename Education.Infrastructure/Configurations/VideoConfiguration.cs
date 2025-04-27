using Education.Persistence.Videos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal sealed class VideoConfiguration : SoftDeleteEntityConfiguration<Video>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Video> builder)
    {
        builder.ToTable("videos",
            tb => tb.HasCheckConstraint("CK_Video_OrderNumber_Positive", "\"order_number\" > 0"));

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Title)
            .IsRequired();

        builder.Property(v => v.Url)
            .IsRequired();

        builder.Property(v => v.OrderNumber)
            .IsRequired();
    }
}
