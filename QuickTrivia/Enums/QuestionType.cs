using System.Text.Json.Serialization;

namespace QuickTrivia.Models
{
    public enum QuestionType
    {
        [JsonPropertyName("multiple")]
        MultipleChoice,

        [JsonPropertyName("boolean")]
        TrueFalse
    }
}
