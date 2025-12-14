using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    public class AppDataDto
    {
        public List<TodoDto> Todos { get; set; } = new();
        public List<WishDto> Wishes { get; set; } = new();
        public List<IncomeDto> Incomes { get; set; } = new();
        public List<ExpenseDto> Expenses { get; set; } = new();
    }

    public interface IDataStorage
    {
        Task SaveAsync(MainPageViewModel vm);
        Task LoadAsync(MainPageViewModel vm);
    }

    public class JsonDataStorage : IDataStorage
    {
        readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        public async Task SaveAsync(MainPageViewModel vm)
        {
            var dto = new AppDataDto
            {
                Todos = vm.Todos.Select(x => new TodoDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    IsCompleted = x.IsCompleted
                })
                .ToList(),

                Wishes = vm.Wishes.Select(x => new WishDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    IsPurchased = x.IsPurchased,
                    Price = x.Price
                })
                .ToList(),

                Incomes = vm.Incomes.Select(x => new IncomeDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    CreatedAt = x.CreatedAt
                })
                .ToList(),

                Expenses = vm.Expenses.Select(x => new ExpenseDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    CreatedAt = x.CreatedAt,
                    ImagePath = x.ImagePath
                })
                .ToList()
            };

            var json = JsonSerializer.Serialize(dto, _options);
            await File.WriteAllTextAsync(AppPaths.DataFilePath, json);
        }

        public async Task LoadAsync(MainPageViewModel vm)
        {
            if (!File.Exists(AppPaths.DataFilePath))
            {
                return;
            }

            var json = await File.ReadAllTextAsync(AppPaths.DataFilePath);
            var dto = JsonSerializer.Deserialize<AppDataDto>(json, _options);

            if (dto is null)
            {
                return;
            }

            vm.Todos.Clear();
            foreach (var t in dto.Todos)
            {
                vm.Todos.Add(new Todo
                {
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    CreatedAt = t.CreatedAt ?? DateTime.UtcNow
                });
            }

            vm.Wishes.Clear();
            foreach (var w in dto.Wishes)
            {
                vm.Wishes.Add(new Wish
                {
                    Title = w.Title,
                    Description = w.Description,
                    CreatedAt = w.CreatedAt,
                    IsPurchased = w.IsPurchased,
                    Price = w.Price
                });
            }

            vm.Incomes.Clear();
            foreach (var i in dto.Incomes)
            {
                vm.Incomes.Add(new Income
                {
                    Title = i.Title,
                    Description = i.Description,
                    CreatedAt = i.CreatedAt,
                    Price = i.Price
                });
            }

            vm.Expenses.Clear();
            foreach (var e in dto.Expenses)
            {
                vm.Expenses.Add(new Expense
                {
                    Title = e.Title,
                    Description = e.Description,
                    CreatedAt = e.CreatedAt,
                    ImagePath = e.ImagePath,
                    Price = e.Price
                });
            }
        }
    }
}
