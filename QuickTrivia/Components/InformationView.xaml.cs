namespace QuickTrivia.Components;

public partial class InformationView : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(InformationView), default(string));

    public static readonly BindableProperty TitleAlignmentProperty =
        BindableProperty.Create(nameof(TitleAlignment), typeof(LayoutOptions),typeof(InformationView),LayoutOptions.Center);

    public static readonly BindableProperty SubtextProperty =
        BindableProperty.Create(nameof(Subtext), typeof(string), typeof(InformationView), default(string));


    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public LayoutOptions TitleAlignment
    {
        get => (LayoutOptions)GetValue(TitleAlignmentProperty);
        set => SetValue(TitleAlignmentProperty, value);
    }

    public string Subtext
    {
        get => (string)GetValue(SubtextProperty);
        set => SetValue(SubtextProperty, value);
    }

    public InformationView()
    {
        InitializeComponent();
    }
}