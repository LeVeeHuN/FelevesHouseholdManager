using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    public partial class Expense : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        string? description;

        [ObservableProperty]
        int price;

        [ObservableProperty]
        DateTime createdAt;

        [ObservableProperty]
        string? imagePath;
    }

    public class ExpenseDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImagePath { get; set; }
    }
}
