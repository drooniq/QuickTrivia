using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuickTrivia.Models;
using QuickTrivia.Services;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Maui.Graphics;
using AndroidX.CoordinatorLayout.Widget;

namespace QuickTrivia.ViewModels
{
    public partial class QuestionViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<Question> Questions { get; set; } = new();

        private ObservableCollection<Answer> _answers;
        public ObservableCollection<Answer> Answers
        {
            get => _answers;
            set {
                SetProperty(ref _answers, value);
                OnPropertyChanged(nameof(Answers));
            }
        }

        private int _currentQuestionIndex;

        [ObservableProperty]
        private Question? currentQuestion;

        private bool IsAnswered = false;

        public bool CanExecuteNextQuestion => Questions.Count > 0 && _currentQuestionIndex < Questions.Count - 1;
        public bool CanExecuteAnswerButtons => IsAnswered is false;

        public QuestionViewModel(ApiService apiService)
        {
            _currentQuestionIndex = 0;
            _apiService = apiService;
            Answers = new();
            Questions = new();
        }

        public void CreateAnswers()
        {
            Answers.Clear();
            if (CurrentQuestion == null)
                return;
            
            foreach (var answer in CurrentQuestion.IncorrectAnswers)
            {
                Answers.Add(
                    new Answer(
                        answer,
                        answer.Equals(CurrentQuestion.CorrectAnswer)
                ));
            }
        }

        public async Task LoadQuestionsAsync()
        {
            var fetchedQuestions = await _apiService.GetQuestionsAsync();

            foreach (var question in fetchedQuestions)
            {
                question?.IncorrectAnswers?.Add(question.CorrectAnswer);
                RandomizeOrderOfAnswers(question.IncorrectAnswers);
                Questions.Add(DecodeHtmlEntitiesInQuestion(question));
            }

            if (Questions.Any())
            {
                CurrentQuestion = Questions[_currentQuestionIndex];
            }

            OnPropertyChanged(nameof(CanExecuteNextQuestion));
            CreateAnswers();
        }

        private string DecodeHtmlEntities(string input)
        {
            return WebUtility.HtmlDecode(input);
        }

        private void RandomizeOrderOfAnswers(List<string> listOfAnswers)
        {
            if (listOfAnswers == null || listOfAnswers.Count <= 1) return;

            Random rng = new Random();
            int numberOfAnswers = listOfAnswers.Count;

            while (numberOfAnswers > 1)
            {
                numberOfAnswers--;
                int rndNumber = rng.Next(numberOfAnswers + 1);

                string value = listOfAnswers[rndNumber];
                listOfAnswers[rndNumber] = listOfAnswers[numberOfAnswers];
                listOfAnswers[numberOfAnswers] = value;
            }
        }

        [RelayCommand(CanExecute = nameof(CanExecuteNextQuestion))]
        public void NextQuestion()
        {
            if (_currentQuestionIndex < Questions.Count - 1)
            {
                _currentQuestionIndex++;
                CurrentQuestion = Questions[_currentQuestionIndex];

                NextQuestionCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(CanExecuteNextQuestion));

                IsAnswered = false;
                CreateAnswers();
            }
        }

        [RelayCommand(CanExecute = nameof(CanExecuteAnswerButtons))]
        public void ChosenAnswer(Answer selectedAnswer)
        {
            IsAnswered = true;

            foreach (var answer in Answers)
            {
                if (answer.IsCorrect && answer.Equals(selectedAnswer))
                    answer.BackgroundColor = Colors.Green;
                else if (answer.Equals(selectedAnswer))
                    answer.BackgroundColor = Colors.Red;
                else if (answer.IsCorrect)
                    answer.BackgroundColor = Colors.Green;
            }

            //foreach(var answer in Answers)
            //{
            //    if (answer.IsCorrect)
            //    {
            //        answer.Text = "CORRECT ANSWER";
            //    }
            //    else
            //    {
            //        answer.Text = "WRONG ANSWER";
            //    }

            //}

            //foreach (var answer in Answers)
            //{
            //    answer.BackgroundColor = answer.IsCorrect ? Color.FromRgba(0, 255, 0, 100) : Color.FromRgba(255, 0, 0, 100);
            //}
        }

        private Question DecodeHtmlEntitiesInQuestion(Question question)
        {
            if (question == null)
                return null;

            // Decode the QuestionText
            question.QuestionText = DecodeHtmlEntities(question.QuestionText);

            // Decode each IncorrectAnswer in the list
            for (int i = 0; i < question.IncorrectAnswers.Count; i++)
            {
                question.IncorrectAnswers[i] = DecodeHtmlEntities(question.IncorrectAnswers[i]);
            }

            return question;
        }
    }
}