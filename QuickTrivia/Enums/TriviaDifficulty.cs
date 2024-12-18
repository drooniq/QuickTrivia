using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuickTrivia.Enums
{
    public enum TriviaDifficulty
    {
        [JsonPropertyName("easy")]
        Easy,
        [JsonPropertyName("medium")]
        Medium,
        [JsonPropertyName("hard")]
        Hard
    }
}
