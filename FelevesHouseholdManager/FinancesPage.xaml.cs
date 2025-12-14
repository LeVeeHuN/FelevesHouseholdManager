using CommunityToolkit.Mvvm.Messaging;

namespace FelevesHouseholdManager;

public partial class FinancesPage : ContentPage
{
	FinancesPageViewModel viewModel;
	public FinancesPage(FinancesPageViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
		WeakReferenceMessenger.Default.Register<string>(this, async (r, m) => await Shell.Current.DisplayAlert("Warning", m, "OK"));
    }
}