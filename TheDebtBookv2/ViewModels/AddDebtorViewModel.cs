using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBookv2.Data;
using TheDebtBookv2.Models;

namespace TheDebtBookv2.ViewModels
{
    public partial class AddDebtorViewModel : ObservableObject
    {
        private Database _database = new Database();
        [ObservableProperty] private string? name;

        [RelayCommand]
        public void AddDebtor()
        {
            if(string.IsNullOrEmpty(name))
            {
                return;
            }

            var debtor = new Debtor()
            {
                Name = name
            };

            AddDebtorAsync(debtor);
        }

        private async void AddDebtorAsync(Debtor debtor)
        {
            await _database.AddDebtor(debtor);
            Name = "";
        }
    }
}
