using Controls.DialogViewModels;
using Core.Attributes;

namespace Controls.DialogViews;

[IocForDialog(typeof(TestDialogViewModel))]
public partial class TestDialog : ContentView
{
    public TestDialog()
    {
        InitializeComponent();
    }
}