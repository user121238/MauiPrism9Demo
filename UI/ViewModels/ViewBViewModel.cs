using System.Windows.Input;
using Core;
using UI.Views;

namespace UI.ViewModels
{
    public class ViewBViewModel(IRegionManager regionManager) : BindableBase
    {
        public ICommand GoBackCommand => new DelegateCommand(() =>
        {
            regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ViewA));
        });
    }
}
