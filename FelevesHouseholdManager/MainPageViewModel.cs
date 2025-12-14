using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<Todo> Todos { get; }
        public ObservableCollection<Wish> Wishes { get; }
        public ObservableCollection<Income> Incomes { get; }
        public ObservableCollection<Expense> Expenses { get; }

        public MainPageViewModel(TodoPageViewModel todoVM, WishPageViewModel wishVM, FinancesPageViewModel financesVM)
        {
            Todos = todoVM.Todos;
            Wishes = wishVM.Wishes;
            Incomes = financesVM.Incomes;
            Expenses = financesVM.Expenses;
        }
    }
}
