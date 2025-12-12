using CommunityToolkit.Mvvm.Messaging;

namespace FelevesHouseholdManager;

public partial class TodoPage : ContentPage
{
	TodoPageViewModel viewModel;
	public TodoPage(TodoPageViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
		WeakReferenceMessenger.Default.Register<string>(this, async (r, m) => await Shell.Current.DisplayAlert("Warning", m, "OK"));
	}
}