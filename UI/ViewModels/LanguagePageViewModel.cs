using Core.Abstracts;
using Core.Enums;
using Core.Infrastructures;
using MyResources.Languages;
using System.Windows.Input;

namespace UI.ViewModels
{
    public class LanguagePageViewModel(
        UiAppContext appContext,
        IEventAggregator eventAggregator,
        IRegionManager regionManager,
        IDialogService dialogService) : RegionViewModelBase(appContext, eventAggregator, regionManager, dialogService)
    {
        public ICommand SwitchLanguageCommand => new Command(SwitchLanguage);

        private void SwitchLanguage()
        {
            var currentLanguage = Application.Current.Resources.MergedDictionaries.OfType<ILanguage>().FirstOrDefault();

            if (currentLanguage is ResourceDictionary rs)
            {
                Application.Current.Resources.MergedDictionaries.Remove(rs);
            }

            var old = Preferences.Get(SettingsKey.LanguageKey, LanguageKey.Chinese.ToString());

            if (old == LanguageKey.Chinese.ToString())
            {
                Application.Current.Resources.MergedDictionaries.Add(new en_US());
                Preferences.Set(SettingsKey.LanguageKey, LanguageKey.English.ToString());
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new zh_CN());
                Preferences.Set(SettingsKey.LanguageKey, LanguageKey.Chinese.ToString());
            }
        }
    }
}
