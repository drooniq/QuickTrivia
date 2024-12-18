using CommunityToolkit.Mvvm.ComponentModel;

namespace QuickTrivia.Models
{
    public class Answer : ObservableObject
    {
        private string text;
        private bool isCorrect;
        private Color backgroundColor = (Color)Application.Current.Resources["LightestPurple"];

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value); // Simplified way to notify UI of property change
        }

        public bool IsCorrect
        {
            get => isCorrect;
            set => SetProperty(ref isCorrect, value);
        }

        public Color BackgroundColor
        {
            get => backgroundColor;
            set => SetProperty(ref backgroundColor, value);
        }

        public Answer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}