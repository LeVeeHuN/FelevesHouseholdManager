using System.Threading.Tasks;

namespace FelevesHouseholdManager;

public partial class NewTodoPage : ContentPage
{
	public Todo NewTodo { get; set; }

    public NewTodoPage()
	{
        InitializeComponent();
		NewTodo = new Todo();
		BindingContext = NewTodo;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        NewTodo.CreatedAt = DateTime.UtcNow;

        var param = new ShellNavigationQueryParameters
        {
            { "newtodo", NewTodo }
        };
        await Shell.Current.GoToAsync("..", param);
    }
}