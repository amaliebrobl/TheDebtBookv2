using Microsoft.Maui.Controls;
using TheDebtBookv2.ViewModels;

namespace TheDebtBookv2.ContentViews;

public partial class DebtListView : ContentView
{
    DebtListViewModel _viewModel;

    public DebtListView(INavigation navigation)
    {
        _viewModel = new DebtListViewModel(navigation);
        InitializeComponent();
        BindingContext = _viewModel;
    }
}