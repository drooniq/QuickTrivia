using Microsoft.Extensions.Logging;
using QuickTrivia.Services;
using QuickTrivia.ViewModels;

namespace QuickTrivia
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddTransient<QuestionPage>();
            builder.Services.AddTransient<QuestionViewModel>();
            builder.Services.AddTransient<ResultPage>();
            builder.Services.AddTransient<ResultViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
