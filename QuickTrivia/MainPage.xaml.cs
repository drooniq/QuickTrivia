using QuickTrivia.ViewModels;

namespace QuickTrivia
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
            _serviceProvider = serviceProvider;
        }

        public async void OnPlayTriviaClicked(object sender, EventArgs e)
        {
            var QuestionPage = _serviceProvider.GetRequiredService<QuestionPage>();
            await Navigation.PushAsync(QuestionPage);
        }
    }
}
