using System;
using System.Collections.Generic;
using System.Linq;

namespace CostManagement
{
    public class ExpenseManager
    {
        private List<Expense> expenses = new List<Expense>();
        private int nextId = 1;

        public void AddExpense(string description, decimal amount, DateTime date)
        {
            expenses.Add(new Expense
            {
                Id = nextId++,
                Description = description,
                Amount = amount,
                Date = date
            });
        }

        public void EditExpense(int id, string description, decimal amount, DateTime date)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expense.Description = description;
                expense.Amount = amount;
                expense.Date = date;
            }
        }

        public void DeleteExpense(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expenses.Remove(expense);
            }
        }

        public List<Expense> GetExpenses()
        {
            return expenses;
        }

        public decimal GetTotalBalance()
        {
            return expenses.Sum(e => e.Amount);
        }
    }
}
