using System.Windows.Input;
using Core;
using UI.Views;

namespace UI.ViewModels
{
    public class ViewAViewModel(IRegionManager regionManager) : BindableBase
    {
        public ICommand ToViewBCommand => new DelegateCommand(() =>
        {
            regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ViewB));
        });
    }
}