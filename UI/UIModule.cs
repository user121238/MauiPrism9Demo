using Core;
using Core.Extensions;
using System.Reflection;
using UI.Views;

namespace UI
{
    public class UiModule(IRegionManager regionManager) : IModule
    {
        #region Implementation of IModule

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        public void RegisterTypes(IContainerRegistry container)
        {
            //container.RegisterForRegionNavigation<ViewA, ViewAViewModel>();
            //container.RegisterForRegionNavigation<ViewB, ViewBViewModel>();

            container.RegisterAllViewModel(Assembly.GetAssembly(typeof(UiModule))!);
        }

        /// <summary>Notifies the module that it has been initialized.</summary>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, nameof(ViewA));
        }

        #endregion
    }
}