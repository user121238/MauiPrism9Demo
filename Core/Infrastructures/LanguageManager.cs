using Core.Enums;
using Core.Events;

namespace Core.Infrastructures
{
    public static class LanguageManager
    {
        /// <summary>
        /// 设置当前语言
        /// </summary>
        /// <param name="language"></param>
        public static void SetCurrentLanguage(LanguageKey language)
        {
            var eventAggregator = ContainerLocator.Current.Resolve<IEventAggregator>();

            eventAggregator.GetEvent<ChangeLanguageEvent>().Publish(language);

            Preferences.Set(SettingsKey.LanguageKey, language.ToString());
        }

        /// <summary>
        /// 获取当前语言
        /// </summary>
        /// <returns></returns>
        public static LanguageKey GetCurrentLanguage()
        {
            Enum.TryParse(Preferences.Get(SettingsKey.LanguageKey, LanguageKey.Chinese.ToString()),
                out LanguageKey currentLanguage);

            return currentLanguage;
        }
    }
}
