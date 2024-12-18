using QuickTrivia.Models;
using QuickTrivia.ViewModels;
using System.ComponentModel;

namespace QuickTrivia;

public partial class QuestionPage : ContentPage
{
    public QuestionPage(QuestionViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        viewModel.LoadQuestionsAsync();
    }
}
