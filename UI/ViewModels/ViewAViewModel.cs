using Controls.DialogViews;
using Core;
using Core.Dtos;
using Core.Events;
using Core.Infrastructures;
using System.Diagnostics;
using System.Windows.Input;
using UI.Views;

namespace UI.ViewModels
{
    public class ViewAViewModel(
        UiAppContext appContext,
        IRegionManager regionManager,
        IEventAggregator eventAggregator,
        IDialogService dialogService)
        : RegionViewModelBase(appContext, eventAggregator, regionManager, dialogService)
    {
        private readonly IRegionManager _regionManager = regionManager;
        private readonly IEventAggregator _eventAggregator = eventAggregator;
        private readonly IDialogService _dialogService = dialogService;

        public ICommand ToViewBCommand => new DelegateCommand(() =>
        {
            _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ViewB));
        });

        public ICommand PublishEventCommand => new DelegateCommand(() =>
        {
            _eventAggregator.GetEvent<EventTest>().Publish(new EventTestDto("这是一个Title",
                $"这是一个Content，发布时间为：{DateTime.Now:yyy-MM-dd HH:mm:ss}"));

            appContext.Logger.Information("发布消息");

            _dialogService.ShowDialog(
                name: nameof(TestDialog),
                parameters: new DialogParameters
                {
                    { "key", "value" }
                }, callback: result => { Debug.WriteLine(result); });
        });
    }
}