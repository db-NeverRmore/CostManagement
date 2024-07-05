using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CostManagement
{
    public class Expense
    {
        public int Id { get; set; } // индефикатор для рассходов
        public string Description { get; set; } // Описание расхода и на что он был потрачен
        public decimal Amount { get; set; } // сумма расхода
        public DateTime Date { get; set; } // время когда был совершен расход
    }
}
