using CommunityToolkit.Mvvm.Messaging;

namespace FelevesHouseholdManager;

public partial class WishPage : ContentPage
{
	WishPageViewModel viewModel;
	public WishPage(WishPageViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
        WeakReferenceMessenger.Default.Register<string>(this, async (r, m) => await Shell.Current.DisplayAlert("Warning", m, "OK"));
    }
}