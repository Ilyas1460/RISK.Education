using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class
    PublicOpenQuestionSelectedAnswerConfiguration : SoftDeleteEntityConfiguration<PublicOpenQuestionSelectedAnswer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PublicOpenQuestionSelectedAnswer> builder)
    {
        builder.ToTable("public_open_question_selected_answers");

        builder.Property(e => e.Answer).IsRequired();
        builder.Property(e => e.PublicQuestionAnswerId).IsRequired(false);

        builder.HasOne(d => d.PublicQuestionAnswer)
            .WithMany(p => p.PublicOpenQuestionSelectedAnswers)
            .HasForeignKey(d => d.PublicQuestionAnswerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
