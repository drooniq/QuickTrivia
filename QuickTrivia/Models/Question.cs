﻿using CommunityToolkit.Mvvm.ComponentModel;
using QuickTrivia.Enums;
using System.Text.Json.Serialization;

namespace QuickTrivia.Models
{
    public partial class Question
    {
        public Question()
        {
        }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
        
        [JsonPropertyName("question")]
        public string QuestionText { get; set; }
        
        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }
    }
}
