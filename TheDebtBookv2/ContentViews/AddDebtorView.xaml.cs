using TheDebtBookv2.ViewModels;

namespace TheDebtBookv2.ContentViews;

public partial class AddDebtorView : ContentView
{
    AddDebtorViewModel _viewModel = new AddDebtorViewModel();
    public AddDebtorView()
	{
		InitializeComponent();
	    BindingContext = _viewModel;
	}
}