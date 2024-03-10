using TheDebtBookv2.ContentViews;
namespace TheDebtBookv2.Pages;

public partial class ShowDebtor : ContentPage
{
	public ShowDebtor(int debtorId)
	{
		InitializeComponent();
        Content = new DebtorView(debtorId);
    }
}