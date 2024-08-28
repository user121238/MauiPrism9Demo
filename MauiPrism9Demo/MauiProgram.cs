using System.Diagnostics;
using Core;
using Microsoft.Extensions.Logging;
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
                    configureCatalog.AddModule<CoreModule>();
                    configureCatalog.AddModule<UiModule>();
                });

                //prism.OnInitialized((container) =>
                //{
                //    var moduleManager = container.Resolve<IModuleManager>();
                //    foreach (var module in moduleManager.Modules)
                //    {
                //        Debug.WriteLine($"模块名称：{module.ModuleType}--状态：{module.State}");
                //        if (module.ModuleName.Contains(nameof(UiModule)) && module.State == ModuleState.NotStarted)
                //        {
                //            moduleManager.LoadModule(module.ModuleName);
                //        }
                //    }

                //    Debug.WriteLine("加载完成！！！");
                //});

                //导航到根目录
                //  prism.CreateWindow(navigationService => navigationService.NavigateAsync($"/{nameof(MainPage)}"));
                prism.CreateWindow("/MainPage", ex =>
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