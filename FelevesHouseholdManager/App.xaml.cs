namespace FelevesHouseholdManager
{
    public partial class App : Application
    {
        private readonly MainPageViewModel _mainVm;
        private readonly IDataStorage _dataStore;

        public App(MainPageViewModel mainVm, IDataStorage dataStore)
        {
            InitializeComponent();
            _mainVm = mainVm;
            _dataStore = dataStore;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await _dataStore.LoadAsync(_mainVm);
        }

        protected override async void OnSleep()
        {
            base.OnSleep();
            await _dataStore.SaveAsync(_mainVm);
        }
    }
}