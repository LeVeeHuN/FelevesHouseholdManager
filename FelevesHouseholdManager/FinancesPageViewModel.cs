using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    [QueryProperty(nameof(NewExpense), "newxpense")]
    [QueryProperty(nameof(NewIncome), "newincome")]
    public partial class FinancesPageViewModel : ObservableObject
    {
        public ObservableCollection<Expense> Expenses { get; private set; }
        public ObservableCollection<Income> Incomes { get; private set; }

        [ObservableProperty]
        Expense selectedExpense;

        [ObservableProperty]
        Income selectedIncome;

        public Expense NewExpense
        {
            set { Expenses.Add(value); }
        }

        public Income NewIncome
        {
            set { Incomes.Add(value); }
        }

        public FinancesPageViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            Incomes = new ObservableCollection<Income>();
        }

        [RelayCommand]
        async Task AddNewExpenseAsync()
        {
            await Shell.Current.GoToAsync("newexpense");
        }

        [RelayCommand]
        async Task AddNewIncomeAsync()
        {
            await Shell.Current.GoToAsync("newincome");
        }

        [RelayCommand]
        void DeleteSelectedExpense()
        {
            if (SelectedExpense != null)
            {
                Expenses.Remove(SelectedExpense);
                SelectedExpense = null;
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Select an item to delete");
            }
        }

        [RelayCommand]
        void DeleteSelectedIncome()
        {
            if (SelectedIncome != null)
            {
                Incomes.Remove(SelectedIncome);
                SelectedIncome = null;
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Select an item to delete");
            }


        }
    }
}
