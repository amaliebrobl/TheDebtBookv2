using TheDebtBookv2.ContentViews;

namespace TheDebtBookv2.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        var debtListView = new DebtListView(Navigation);
        Grid.SetColumn(debtListView, 0);
        Grid.SetColumnSpan(debtListView, 2);
        ((Grid)Content).Children.Add(debtListView);
    }

    private void AddDebtor_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddDebtor());
    }
}