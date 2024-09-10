using Core;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System.Diagnostics;
using CommunityToolkit.Maui;
using Controls;
using MauiPrism9Demo.ViewModels;
using UI;
using UraniumUI;


namespace MauiPrism9Demo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();


            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddMaterialIconFonts();
            });

            builder.UseUraniumUI().UseUraniumUIMaterial();


#if DEBUG
            //启用日志调试
            Serilog.Debugging.SelfLog.Enable(Console.Error);
#endif


            builder.UsePrism(prism =>
            {
                prism.RegisterTypes(container => { container.RegisterForNavigation<MainPage, MainPageViewModel>(); });


                prism.ConfigureLogging(configureLogging =>
                {
                    var logConfig = new LoggerConfiguration();

                    logConfig.WriteTo.Async((skinConfig) =>
                    {
                        var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

#if ANDROID
                        var androidPaths = Android.App.Application.Context.GetExternalFilesDirs(null);
                        basePath = androidPaths[0].AbsolutePath;
#endif

                        var baseLogPath = Path.Combine(basePath, "logs");

                        skinConfig.File(path: $"{baseLogPath}/.log",
                            restrictedToMinimumLevel: LogEventLevel.Verbose,
                            rollingInterval: RollingInterval.Day);
                    });

                    Log.Logger = logConfig.CreateLogger();

                    configureLogging.Services.AddSerilog(Log.Logger);
                });


                prism.ConfigureModuleCatalog(configureCatalog =>
                {
                    configureCatalog.AddModule<CoreModule>(InitializationMode.OnDemand);
                    configureCatalog.AddModule<ControlModule>();
                    configureCatalog.AddModule<UiModule>();
                });


                //导航到根目录
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