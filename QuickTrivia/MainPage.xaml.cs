using QuickTrivia.ViewModels;

namespace QuickTrivia
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        public async void OnPlayTriviaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionPage());
        }
    }
}
