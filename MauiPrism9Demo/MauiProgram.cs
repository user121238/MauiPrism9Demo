using Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UI;

namespace MauiPrism9Demo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();


            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

            builder.UsePrism(prism =>
            {
                prism.RegisterTypes(container => { container.RegisterForNavigation<MainPage>(); });

                prism.ConfigureModuleCatalog(configureCatalog =>
                {
                    configureCatalog.AddModule<CoreModule>(InitializationMode.OnDemand);
                    configureCatalog.AddModule<UiModule>();
                });

                //导航到根目录
                // prism.CreateWindow(navigationService => navigationService.NavigateAsync($"/{nameof(MainPage)}"));
                prism.CreateWindow($"/{nameof(MainPage)}", ex =>
                {
                    Debug.Write(ex.StackTrace);
                    throw ex;
                });
            });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}