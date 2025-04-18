using Education.Persistence.Videos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal class VideoConfiguration : SoftDeleteEntityConfiguration<Video> {
    protected override void ConfigureEntity(EntityTypeBuilder<Video> builder) {
        builder.ToTable("videos", 
            tb => tb.HasCheckConstraint("CK_Video_OrderNumber_Positive", "\"OrderNumber\" > 0"));

        builder.HasKey(v => v.VideoId);

        builder.Property(v => v.Title)
            .IsRequired();

        builder.Property(v => v.Url)
            .IsRequired();

        builder.Property(v => v.OrderNumber)
            .IsRequired();
    }
}