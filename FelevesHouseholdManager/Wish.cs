using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    public partial class Wish : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        string? description;

        [ObservableProperty]
        DateTime createdAt;

        [ObservableProperty]
        bool isPurchased;

        [ObservableProperty]
        int price;
    }

    public class WishDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt {  get; set; }
        public bool IsPurchased { get; set; }
        public int Price { get; set; }
    }
}
