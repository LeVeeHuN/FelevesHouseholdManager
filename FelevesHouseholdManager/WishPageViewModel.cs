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
    [QueryProperty(nameof(NewWish), "newwish")]
    public partial class WishPageViewModel : ObservableObject
    {
        public ObservableCollection<Wish> Wishes { get; private set; }

        [ObservableProperty]
        Wish selectedWish;

        public Wish NewWish
        {
            set { Wishes.Add(value); }
        }

        public WishPageViewModel()
        {
            Wishes = new ObservableCollection<Wish>();
        }

        [RelayCommand]
        async Task AddNewAsync()
        {
            await Shell.Current.GoToAsync("newwish");
        }

        [RelayCommand]
        void DeleteSelected()
        {
            if (SelectedWish != null)
            {
                Wishes.Remove(SelectedWish);
                SelectedWish = null;
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Select an item to delete");
            }
        }

        [RelayCommand]
        void MarkSelectedAsCompleted()
        {
            if (SelectedWish != null)
            {
                SelectedWish.IsPurchased = true;
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Select an item to mark as purchased");
            }
        }

        [RelayCommand]
        async Task ShareSelected()
        {
            if (SelectedWish != null)
            {
                string desc = SelectedWish.Description ?? "No description provided.";
                await Share.Default.RequestAsync(new ShareTextRequest()
                {
                    Title = $"Wish: {SelectedWish.Title}",
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
