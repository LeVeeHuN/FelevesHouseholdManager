namespace FelevesHouseholdManager;

public partial class NewIncomePage : ContentPage
{
	public Income NewIncome { get; set; }

	public NewIncomePage()
	{
		InitializeComponent();
		NewIncome = new Income();
		BindingContext = NewIncome;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		NewIncome.CreatedAt = DateTime.UtcNow;
		var param = new ShellNavigationQueryParameters
		{
			{ "newincome", NewIncome }
		};
		await Shell.Current.GoToAsync("..", param);
    }
}