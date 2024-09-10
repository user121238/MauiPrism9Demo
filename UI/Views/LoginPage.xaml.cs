using Core.Attributes;
using UI.ViewModels;

namespace UI.Views;

[IocForRegionNavigation(typeof(LoginPageViewModel))]
public partial class LoginPage : ContentView
{
    public LoginPage()
    {
        InitializeComponent();
    }
}