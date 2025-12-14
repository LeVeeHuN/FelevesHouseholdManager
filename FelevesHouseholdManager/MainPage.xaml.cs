using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TodoPage");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//WishPage");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//FinancesPage");
        }
    }
}
