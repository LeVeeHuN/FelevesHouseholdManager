namespace FelevesHouseholdManager;

public partial class NewExpensePage : ContentPage
{
	public Expense NewExpense { get; set; }

    public NewExpensePage()
	{
		InitializeComponent();
		NewExpense = new Expense();
		BindingContext = NewExpense;
    }

    private async void TakePhotoBtn_Clicked(object sender, EventArgs e)
    {
        FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

        if (photo == null)
        {
            return;
        }

        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

        using Stream sourceStream = await photo.OpenReadAsync();
        using FileStream localFileStream = File.OpenWrite(localFilePath);
        await sourceStream.CopyToAsync(localFileStream);
        NewExpense.ImagePath = localFilePath;
        return;
    }

    private async void SelectPhotoBtn_Clicked(object sender, EventArgs e)
    {
        FileResult? photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Pick a photo"
        });

        if (photo == null)
        {
            return;
        }

        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

        using Stream sourceStream = await photo.OpenReadAsync();
        using FileStream localFileStream = File.OpenWrite(localFilePath);
        await sourceStream.CopyToAsync(localFileStream);
        NewExpense.ImagePath = localFilePath;
        return;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        NewExpense.CreatedAt = DateTime.UtcNow;
        var param = new ShellNavigationQueryParameters
        {
            { "newxpense", NewExpense }
        };
        await Shell.Current.GoToAsync("..", param);
    }
}