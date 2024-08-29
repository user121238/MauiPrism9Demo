using Core.Attributes;
using UI.ViewModels;

namespace UI.Views;

[IocForRegionNavigation(typeof(ViewAViewModel))]
public partial class ViewA : ContentView
{
    public ViewA()
    {
        InitializeComponent();
    }
}