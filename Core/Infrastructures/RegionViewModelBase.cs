using Core.Abstracts;

namespace Core.Infrastructures
{
    /// <summary>
    /// 区域导航基础
    /// </summary>
    /// <param name="appContext"></param>
    /// <param name="regionManager"></param>
    /// <param name="dialogService"></param>
    public abstract class RegionViewModelBase(
        IAppContext appContext,
        IEventAggregator eventAggregator,
        IRegionManager regionManager,
        IDialogService dialogService
    ) : BindableBase, IRegionMemberLifetime, IPageLifecycleAware,
        INavigationAware
    {
        #region Implementation of IRegionMemberLifetime

        /// <summary>
        ///获取一个值，该值指示此实例在停用时是否应保持活动状态.
        /// </summary>
        public virtual bool KeepAlive => false;

        #endregion

        #region Implementation of IPageLifecycleAware

        /// <summary>页面出现时调用.</summary>
        public virtual void OnAppearing()
        {
        }

        /// <summary>当页面消失时调用.</summary>
        public virtual void OnDisappearing()
        {
        }

        #endregion

        #region Implementation of INavigatedAware

        /// <summary>
        /// 从当前页面离开时调用。
        /// </summary>
        /// <param name="parameters">The navigation parameters.</param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>从别的页面导航进此页面时调用.</summary>
        /// <param name="parameters">The navigation parameters.</param>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        #endregion
    }
}