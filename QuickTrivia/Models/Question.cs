using QuickTrivia.Enums;

namespace QuickTrivia.Models
{
    public partial class Question
    {
        public QuestionType Type { get; set; }
        public TriviaDifficulty Difficulty { get; set; }
        public TriviaCategory Category { get; set; }
        public string? QuestionText { get; set; }
        public string? CorrectAnswer { get; set; }
        public List<string>? IncorrectAnswers { get; set; }
    }
}
