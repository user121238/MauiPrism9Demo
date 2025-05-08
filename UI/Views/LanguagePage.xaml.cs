using Core.Attributes;
using UI.ViewModels;

namespace UI.Views;

[IocForRegionNavigation(typeof(LanguagePageViewModel))]
public partial class LanguagePage : ContentView
{
    public LanguagePage()
    {
		InitializeComponent();
	}
}