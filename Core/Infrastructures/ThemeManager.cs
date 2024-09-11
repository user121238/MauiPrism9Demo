using Core.Enums;
using Core.Events;

namespace Core.Infrastructures
{
    public static class ThemeManager
    {
        /// <summary>
        /// 设置主题
        /// </summary>
        /// <param name="theme"></param>
        public static void SetCurrentTheme(ThemeKey theme)
        {
            var eventAggregator = ContainerLocator.Current.Resolve<IEventAggregator>();

            eventAggregator.GetEvent<ChangeThemeEvent>().Publish(theme);

            Preferences.Set(SettingsKey.ThemeKey, theme.ToString());
        }

        public static ThemeKey GetCurrentTheme()
        {
            Enum.TryParse(Preferences.Get(SettingsKey.ThemeKey, ThemeKey.Light.ToString()), out ThemeKey currentTheme);

            return currentTheme;
        }
    }
}
