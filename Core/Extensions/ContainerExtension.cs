using Core.Attributes;
using System.Reflection;

namespace Core.Extensions
{
    public static class ContainerExtension
    {
        /// <summary>
        /// 自动注册所有的View和ViewModel
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterAllViewModel(this IContainerRegistry container, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(c => c.BaseType == typeof(ContentView));

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<IocForRegionNavigationAttribute>();

                if (attribute != null)
                {
                    var viewModelType = attribute.ViewModelType;
                    //如果注册名称为空则使用View的名称
                    var registerName = attribute.RegisterName ?? type.Name;

                    container.RegisterForRegionNavigation(type, viewModelType, registerName);
                }
            }
        }


        public static void RegisterAllDialogViewModel(this IContainerRegistry container, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(c => c.BaseType == typeof(ContentView));

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<IocForDialogAttribute>();

                if (attribute != null)
                {
                    var viewModelType = attribute.ViewModelType;
                    //如果注册名称为空则使用View的名称
                    var registerName = attribute.RegisterName ?? type.Name;

                    container.RegisterDialog(type, viewModelType, registerName);
                }
            }
        }
    }
}