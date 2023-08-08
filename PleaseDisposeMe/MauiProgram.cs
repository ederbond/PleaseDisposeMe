using Microsoft.Extensions.Logging;
using PleaseDisposeMe.Services;

namespace PleaseDisposeMe;

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

        builder.Services.AddSingleton<ITimeService, TimeService>()
            .AddTransient<Page1>()
            .AddTransient<Page1ViewModel>()
            .AddTransient<Page2>()
            .AddTransient<Page2ViewModel>();

        Routing.RegisterRoute(nameof(Page2), typeof(Page2));


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
