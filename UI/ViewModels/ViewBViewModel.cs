using System.Windows.Input;
using Core;
using Core.Dtos;
using Core.Events;
using UI.Views;

namespace UI.ViewModels
{
    public class ViewBViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _aggregator;

        public ViewBViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;

            eventAggregator.GetEvent<EventTest>().Subscribe(EventTestHandle);
        }

        private void EventTestHandle(EventTestDto dto)
        {
            TestDto = dto;
            _aggregator.GetEvent<EventTest>().Unsubscribe(EventTestHandle);
        }

        private EventTestDto _testDto;

        public EventTestDto TestDto
        {
            get => _testDto;
            set => SetProperty(ref _testDto, value);
        }


        public ICommand GoBackCommand => new DelegateCommand(() =>
        {
            _regionManager.RequestNavigate(RegionNames.MainRegion, nameof(ViewA));
        });
    }
}
