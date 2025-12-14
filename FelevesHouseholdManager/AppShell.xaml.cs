namespace FelevesHouseholdManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("newtodo", typeof(NewTodoPage));
            Routing.RegisterRoute("newwish", typeof(NewWishPage));
            Routing.RegisterRoute("newexpense", typeof(NewExpensePage));
            Routing.RegisterRoute("newincome", typeof(NewIncomePage));
            Routing.RegisterRoute("edittodo", typeof(EditTodoPage));
        }
    }
}
