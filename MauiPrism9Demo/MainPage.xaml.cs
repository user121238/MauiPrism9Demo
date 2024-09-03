using Android.Content;
using Android.Provider;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using FlowDirection = Microsoft.Maui.FlowDirection;

namespace MauiPrism9Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        #region Overrides of Page

        /// <summary>
        /// When overridden in a derived class, allows application developers to customize behavior immediately prior to the page becoming visible.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        #endregion
    }
}