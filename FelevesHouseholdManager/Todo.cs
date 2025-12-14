using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    public partial class Todo : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        string? description;

        [ObservableProperty]
        DateTime createdAt;

        [ObservableProperty]
        bool isCompleted;
    }

    public class TodoDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
    }
}
