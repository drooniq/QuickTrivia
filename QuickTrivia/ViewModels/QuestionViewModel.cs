using CommunityToolkit.Mvvm.ComponentModel;
using QuickTrivia.Enums;
using QuickTrivia.Models;
using System.Collections.ObjectModel;

namespace QuickTrivia.ViewModels
{
    internal class QuestionViewModel : BaseViewModel
    {
        public ObservableCollection<Question> Questions { get; set; }

        private int _currentQuestionIndex;

        private Question _currentQuestion;
        public Question CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                OnPropertyChanged(); // Notify the UI
            }
        }

        public QuestionViewModel()
        {
            Questions = new ObservableCollection<Question>();
            _currentQuestionIndex = 0;
        }

        public async Task LoadQuestionsAsync()
        {
            var fetchedQuestions = new List<Question>
            {
                //load from API instead of hardcoding
                new Question
                {
                    Type = QuestionType.MultipleChoice,
                    Difficulty = TriviaDifficulty.Easy,
                    Category = TriviaCategory.GeneralKnowledge,
                    QuestionText = "What is .NET MAUI?",
                    CorrectAnswer = "A cross-platform framework.",
                    IncorrectAnswers = new List<string> { "A game engine.", "A database system.", "A web framework." }
                },
                new Question
                {
                    Type = QuestionType.MultipleChoice,
                    Difficulty = TriviaDifficulty.Medium,
                    Category = TriviaCategory.ScienceComputers,
                    QuestionText = "What does API stand for?",
                    CorrectAnswer = "Application Programming Interface",
                    IncorrectAnswers = new List<string> { "Automatic Programming Interface", "Advanced Program Integration", "Application Process Interface" }
                }
            };

            foreach (var question in fetchedQuestions)
            {
                question.IncorrectAnswers.Add(question.CorrectAnswer);
                Questions.Add(question);
            }

            CurrentQuestion = Questions[_currentQuestionIndex];
        }

        public void NextQuestion()
        {
            if (_currentQuestionIndex < Questions.Count - 1)
            {
                _currentQuestionIndex++;
                CurrentQuestion = Questions[_currentQuestionIndex];
            }
        }
    }
}