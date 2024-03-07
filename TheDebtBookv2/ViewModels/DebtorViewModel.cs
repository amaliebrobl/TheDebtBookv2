using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBookv2.Data;
using TheDebtBookv2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Markup;

namespace TheDebtBookv2.ViewModels
{
    public partial class DebtorViewModel : ObservableObject
    {
        private readonly Database _database = new Database();

        [ObservableProperty]
        public Debtor? _debtor;

        [ObservableProperty]
        public Debt? _debt;

        [ObservableProperty]
        public double? debtValue;

        [ObservableProperty]
        public DateTime? date;

        [RelayCommand]
        public void AddDebt()
        {
            if (Debtor == null)
            {
                return;
            }

            var debt = new Debt()
            {
                Value = debtValue ?? 0,
                Date = date ?? DateTime.Now,
                DebtorId = Debtor.Id,
            };

            AddDebtAsync(debt);
            UpdateAccumulatedDebtAsync(debt.DebtorId);
        }

        [RelayCommand]
        public void LoadData()
        {
            if (_debtor == null)
            {
                return;
            }
            LoadDataAsync(_debtor.Id);
        }

        public DebtorViewModel(int debtorId)
        {
            LoadDataAsync(debtorId);
        }

        private async void LoadDataAsync(int debtorId)
        {
            var debtorDatabase = await _database.GetDebtorId(debtorId);
            Debtor = debtorDatabase;
            var debtDatabase = await _database.GetAccumulatedDebt(debtorId);
            Debt = new List<Debt>(debtDatabase);
        }

        private async void AddDebtAsync(Debt debt)
        {
            await _database.AddDebt(debt);
            LoadDataAsync(debt.DebtorId);
        }

        private async void UpdateAccumulatedDebtAsync(int debtorId)
        {
            var debtDatabase = await _database.GetAccumulatedDebt(debtorId);
            var accumulatedDebt = debtDatabase.Sum(x => x.Debt);
            var debtorDatabase = await _database.GetDebtorId(debtorId);
            debtorDatabase.AccumulatedDebt = accumulatedDebt;
            await _database.UpdateDebtorList(debtorDatabase);
            Debtor = debtorDatabase;
        }
    }
}
