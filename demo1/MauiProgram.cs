using Microsoft.Extensions.Logging;
using demo1.Data;
using dymaptic.GeoBlazor.Core;
using Microsoft.Extensions.Configuration;

namespace demo1;

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
			});
        builder.Services.AddGeoBlazor();
        builder.Services.AddMauiBlazorWebView();

		var mapSettings = new Dictionary<string, string> { { "ArcGISApiKey", "INSERT-YOUR-ESRI-API-KEY-HERE" } };
        builder.Configuration.AddInMemoryCollection(mapSettings);


#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
