using Microsoft.Maui.Controls;

namespace QuickTrivia.Components;

public partial class CustomTitleBar : ContentView
{
    public static readonly BindableProperty TitleTextProperty =
        BindableProperty.Create(nameof(TitleText), typeof(string), typeof(CustomTitleBar), string.Empty);

    public string TitleText
    {
        get => (string)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    public CustomTitleBar()
	{
        InitializeComponent();
	}
}