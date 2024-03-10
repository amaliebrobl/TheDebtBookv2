using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBookv2.Models;

namespace TheDebtBookv2.Data
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database()
        {
            var dataDirectory = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDirectory, "TheDebtBookv2.db");

            Directory.CreateDirectory(dataDirectory);

            var dbOptions=new SQLiteConnectionString(databasePath, storeDateTimeAsTicks:true);
            _connection = new SQLiteAsyncConnection(dbOptions);

            Initialize();
        }


        // Laver ny "Debtor" i databasen
        private async Task Initialize()
        {
            await _connection.CreateTableAsync<Debtor>();
            await _connection.CreateTableAsync<Debt>();
        }

        public async Task<List<Debtor>> GetDebtors()
        {
            return await _connection.Table<Debtor>().ToListAsync();
        }

        public async Task<Debtor> GetDebtorId(int DebtorId)
        {
            var query = _connection.Table<Debtor>().Where(t => t.Id == DebtorId);
            return await query.FirstOrDefaultAsync();
        }

        // Tilføjer en "debtor"
        public async Task<int> AddDebtor(Debtor item)
        {
            return await _connection.InsertAsync(item);
        }

        // Tilføjer en "Debt"/value til en bestemt "debtor"
        public async Task<double> AddDebt(Debt item)
        {
            return await _connection.InsertAsync(item);
        }


        // Opdaterer listen på forsiden
        public async Task<int> UpdateDebtorList(Debtor item)
        {
            return await _connection.UpdateAsync(item);
        }

        public async Task<double> UpdateDebtList(Debt item)
        {
            return await _connection.UpdateAsync(item);
        }


        // Samler alle "debts" for én "debtor"
        public async Task<List<Debt>> GetAccumulatedDebt(int id)
        {
            var query = _connection.Table<Debt>().Where(t => t.DebtorId == id);
            return await query.ToListAsync();
        }
    }
}
