using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using TubeTest.Services;
using TubeTest.Services.NativeProcess;
using TubeTest.ViewModel;

namespace TubeTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp(IDependencyModule nativeServices)
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .AddServices(nativeServices)
                .AddViewModel()
                .AddView()
                .AddPopup()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }


        private static MauiAppBuilder AddServices(this MauiAppBuilder builder, IDependencyModule nativeServices)
        {
            nativeServices.Register(builder.Services);

            return builder;
        }

        private static MauiAppBuilder AddViewModel(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainViewModel>();
            return builder;
        }

        private static MauiAppBuilder AddView(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            return builder;
        }

        private static MauiAppBuilder AddPopup(this MauiAppBuilder builder)
        {
            builder.Services.AddTransientPopup<IndicatorPopup, IndicatorViewModel>();
            return builder;
        }

    }
}
