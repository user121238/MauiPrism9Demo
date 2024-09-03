using System.Reflection;
using Controls.DialogViewModels;
using Controls.DialogViews;
using Core.Extensions;

namespace Controls
{
    public class ControlModule : IModule
    {
        #region Implementation of IModule

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<TestDialog, TestDialogViewModel>();
            // containerRegistry.RegisterAllDialogViewModel(Assembly.GetAssembly(typeof(ControlModule))!);
        }

        /// <summary>Notifies the module that it has been initialized.</summary>
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        #endregion
    }
}