using System.Windows.Input;
using Core.Abstracts;
using Core.Enums;
using Core.Events;
using Core.Infrastructures;

namespace UI.ViewModels
{
    public class LoginPageViewModel : RegionViewModelBase
    {
        private readonly UiAppContext _appContext;
        private readonly IEventAggregator _eventAggregator;

        public LoginPageViewModel(UiAppContext appContext,
            IEventAggregator eventAggregator,
            IRegionManager regionManager,
            IDialogService dialogService) : base(appContext, eventAggregator, regionManager, dialogService)
        {
            _appContext = appContext;
            _eventAggregator = eventAggregator;
        }

        public ICommand ModifyThemeCommand => new DelegateCommand(ModifyTheme);

        private string _currentTheme;

        public string CurrentThemeStr
        {
            get => _currentTheme;
            set => SetProperty(ref _currentTheme, value);
        }


        internal void ModifyTheme()
        {
            var currentTheme = ThemeManager.GetCurrentTheme();

            ThemeManager.SetCurrentTheme(currentTheme == ThemeKey.Light ? ThemeKey.Dark : ThemeKey.Light);
        }
    }
}