using Microsoft.Extensions.Logging;

namespace FelevesHouseholdManager
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<TodoPageViewModel>();
            builder.Services.AddSingleton<TodoPage>();
            builder.Services.AddSingleton<WishPageViewModel>();
            builder.Services.AddSingleton<WishPage>();
            builder.Services.AddSingleton<FinancesPageViewModel>();
            builder.Services.AddSingleton<FinancesPage>();

            return builder.Build();
        }
    }
}
