using System.Threading.Tasks;

namespace FelevesHouseholdManager;

public partial class NewWishPage : ContentPage
{
	public Wish NewWish { get; set; }

    public NewWishPage()
	{
		InitializeComponent();
        NewWish = new Wish();
        BindingContext = NewWish;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        NewWish.CreatedAt = DateTime.UtcNow;

        var param = new ShellNavigationQueryParameters
        {
            { "newwish", NewWish }
        };

        await Shell.Current.GoToAsync("..", param);
    }
}