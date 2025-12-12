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
    [QueryProperty(nameof(NewTodo), "newtodo")]
    public partial class TodoPageViewModel : ObservableObject
    {
        public ObservableCollection<Todo> Todos { get; private set; }

        [ObservableProperty]
        Todo selectedTodo;

        public Todo NewTodo
        {
            set { Todos.Add(value); }
        }

        public TodoPageViewModel()
        {
            Todos = new ObservableCollection<Todo>();
        }

        [RelayCommand]
        async Task AddNewAsync()
        {
            await Shell.Current.GoToAsync("newtodo");
        }

        [RelayCommand]
        void DeleteSelected()
        {
            if (SelectedTodo != null)
            {
                Todos.Remove(SelectedTodo);
                SelectedTodo = null;
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Select an item to delete");
            }
        }

        [RelayCommand]
        async Task ShareSelected()
        {
            if (SelectedTodo != null)
            {
                string desc = SelectedTodo.Description ?? "No description provided.";
                await Share.Default.RequestAsync(new ShareTextRequest()
                {
                    Title = $"TODO: {SelectedTodo.Title}",
                    Text = $"{desc}"
                });
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Select an item to share!");
            }
        }
    }
}
