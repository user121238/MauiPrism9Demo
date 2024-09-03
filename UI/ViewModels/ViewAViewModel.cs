using System.Windows.Input;
using Core;
using Core.Dtos;
using Core.Events;
using Serilog;
using UI.Views;

namespace UI.ViewModels
{
    public class ViewAViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger)
        : BindableBase
    {
        public ICommand ToViewBCommand => new DelegateCommand(() =>
        {
            regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ViewB));
        });

        public ICommand PublishEventCommand => new DelegateCommand(() =>
        {
            eventAggregator.GetEvent<EventTest>().Publish(new EventTestDto("这是一个Title",
                $"这是一个Content，发布时间为：{DateTime.Now:yyy-MM-dd HH:mm:ss}"));

            logger.Information("发布消息");
        });
    }
}