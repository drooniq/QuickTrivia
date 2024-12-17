using QuickTrivia.Models;
using QuickTrivia.ViewModels;
using System.ComponentModel;

namespace QuickTrivia;

public partial class QuestionPage : ContentPage
{
    private QuestionViewModel viewModel;
    public QuestionPage()
    {
        InitializeComponent();

        viewModel = new QuestionViewModel();
        BindingContext = viewModel;

        viewModel.LoadQuestionsAsync();
    }

    public async void OnNextQuestionClick(object sender, EventArgs e)
    {
        viewModel.NextQuestion();
    }
}
