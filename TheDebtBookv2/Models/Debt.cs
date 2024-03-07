using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TheDebtBookv2.Models
{
    public class Debt
    {
        [PrimaryKey, AutoIncrement]
        public int DebtId { get; set; }
        public double Value { get; set; } = 0;
        public DateTime Data { get; set; }
        public int DebtorId {  get; set; }
    }
}
