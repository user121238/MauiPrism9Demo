using Core.Attributes;
using UI.ViewModels;

namespace UI.Views;

[IocForRegionNavigation(typeof(ViewBViewModel))]
public partial class ViewB : ContentView
{
    public ViewB()
    {
		InitializeComponent();
	}
}