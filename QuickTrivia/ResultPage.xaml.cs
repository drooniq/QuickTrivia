using QuickTrivia.ViewModels;

namespace QuickTrivia;

public partial class ResultPage : ContentPage
{
    public ResultViewModel ResultViewModel { get; set; }

    public ResultPage(ResultViewModel resultViewModel)
	{
		InitializeComponent();
        ResultViewModel = resultViewModel;
        BindingContext = ResultViewModel;
    }

    private async void OnGoToHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}