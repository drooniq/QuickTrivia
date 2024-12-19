using QuickTrivia.Models;
using QuickTrivia.ViewModels;
using System.ComponentModel;

namespace QuickTrivia;

public partial class QuestionPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    public QuestionPage(QuestionViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _serviceProvider = serviceProvider;

        viewModel.LoadQuestionsAsync();
    }

    private async void OnGoToResultPageClicked(object sender, EventArgs e)
    {
        var ResultPage = _serviceProvider.GetRequiredService<ResultPage>();
        await Navigation.PushAsync(ResultPage);
        //        await Navigation.PopToRootAsync();
    }
}
