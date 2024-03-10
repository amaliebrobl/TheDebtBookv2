using TheDebtBookv2.ViewModels;

namespace TheDebtBookv2.ContentViews;

public partial class DebtorView : ContentView
{
    DebtorViewModel _viewModel;

    public DebtorView(int debtorId)
	{
        _viewModel = new DebtorViewModel(debtorId);
        InitializeComponent();
        BindingContext = _viewModel;
    }
}