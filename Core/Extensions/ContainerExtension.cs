using System.Reflection;
using Core.Attributes;
using Prism.Ioc;

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
                IocForRegionNavigationAttribute? ioc = type.GetCustomAttribute<IocForRegionNavigationAttribute>();

                if (ioc != null)
                {
                    var viewModelType = ioc.ViewModelType;
                    var registerName = ioc.RegisterName ?? type.Name;

                    container.RegisterForRegionNavigation(type, viewModelType, registerName);
                }
            }
        }
    }
}