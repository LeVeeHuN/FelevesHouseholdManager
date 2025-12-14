namespace FelevesHouseholdManager;

[QueryProperty(nameof(EditingTodo), "todo")]
public partial class EditTodoPage : ContentPage
{
	public Todo EditingTodo { get; set; }
    public EditTodoPage()
	{
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        BindingContext = EditingTodo;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}