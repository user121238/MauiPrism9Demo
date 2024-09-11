#if ANDROID
using Android.Content;
using Android.Provider;
#endif

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Core.Abstracts;
using Core.Enums;
using Core.Events;
using MauiPrism9Demo.Resources.Styles;

namespace MauiPrism9Demo.ViewModels
{
    public class MainPageViewModel
        : IRegionMemberLifetime, IPageLifecycleAware, INavigatedAware
    {
        private readonly IPageDialogService _pageDialogService;

        public MainPageViewModel(IPageDialogService pageDialogService, IEventAggregator eventAggregator)
        {
            _pageDialogService = pageDialogService;
            eventAggregator.GetEvent<ChangeThemeEvent>().Subscribe(theme =>
            {
                var m = Application.Current?.Resources.MergedDictionaries;
                if (m == null)
                {
                    return;
                }

                var current = m.OfType<ITheme>().FirstOrDefault();

                if (current is ResourceDictionary rd)
                {
                    m.Remove(rd);
                }

                m.Add(theme == ThemeKey.Light ? new LightTheme() : new DarkTheme());
            });
        }

        #region Implementation of IRegionMemberLifetime

        /// <summary>
        /// 获取一个值，该值指示该实例在停用时是否应保持活动状态。
        /// </summary>
        public bool KeepAlive => true;

        #endregion

        #region Implementation of IApplicationLifecycleAware

        private async Task OnAppResume()
        {
#if ANDROID
            //校验读写权限
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status != PermissionStatus.Granted)
            {
                var result = await Permissions.RequestAsync<Permissions.StorageWrite>();

                if (result != PermissionStatus.Granted)
                {
                    await Toast.Make("此应用程序需要文件读写权限才能使用", ToastDuration.Short).Show();
                    var alertResult =
                        await _pageDialogService.DisplayAlertAsync("提示", "此应用程序需要文件读写权限才能使用", "前往设置", "退出程序");
                    //  var alertResult = await DisplayAlert("提示", "此应用程序需要文件读写权限才能使用", "前往设置", "暂不设置");
                    if (alertResult)
                    {
                        var uri = Android.Net.Uri.FromParts("package", Android.App.Application.Context.PackageName,
                            null);
                        var intent = new Intent(Settings.ActionApplicationDetailsSettings, uri);
                        intent.AddFlags(ActivityFlags.NewTask);
                        Android.App.Application.Context.StartActivity(intent);
                    }
                    else
                    {
                        Environment.Exit(-1);
                    }
                }
            }
#endif
        }

        #endregion

        #region Implementation of IPageLifecycleAware

        /// <summary>Called when the page is appearing.</summary>
        public void OnAppearing()
        {
            _ = OnAppResume();
        }

        /// <summary>Called when the page is disappearing.</summary>
        public void OnDisappearing()
        {
        }

        #endregion

        #region Implementation of INavigatedAware

        /// <summary>
        /// Called when the implementer has been navigated away from.
        /// </summary>
        /// <param name="parameters">The navigation parameters.</param>
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>Called when the implementer has been navigated to.</summary>
        /// <param name="parameters">The navigation parameters.</param>
        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        #endregion
    }
}