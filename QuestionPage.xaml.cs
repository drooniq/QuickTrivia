using QuickTrivia.ViewModels;

namespace QuickTrivia
{
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
