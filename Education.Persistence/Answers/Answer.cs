using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.Answers;

public sealed class Answer : BaseEntity
{
    public string Content { get; private set; }
    public bool IsCorrect { get; private set; }
    public int QuestionId { get; private set; }

    public Question Question { get; set; }

    private Answer(string content, bool isCorrect, int questionId)
    {
        Content = content;
        IsCorrect = isCorrect;
        QuestionId = questionId;
    }

    public static Answer Create(string content, bool isCorrect, int questionId)
    {
        return new Answer(content, isCorrect, questionId);
    }

    public void UpdateContent(string content) => Content = content;

    public void UpdateIsCorrect(bool isCorrect) => IsCorrect = isCorrect;

    public void UpdateQuestionId(int questionId) => QuestionId = questionId;
}
