using System;
using System.Collections.Generic;
using System.Linq;

namespace CostManagement
{
    public class ExpenseManager 
    {
        private List<Expense> expenses = new List<Expense>(); //список всех рассходов 
        private int nextId = 1; // при новом расходе его айдишник будет увеличен

        public void AddExpense(string description, decimal amount, DateTime date) // функция которая добавляет новый рассход 
        {
            expenses.Add(new Expense
            {
                Id = nextId++, // добавление айдишника для рассхода
                Description = description,
                Amount = amount,
                Date = date
            });
        }

        public void EditExpense(int id, string description, decimal amount, DateTime date) // функциия для иземнения рассхода 
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expense.Description = description;
                expense.Amount = amount;
                expense.Date = date;
            }
        }

        public void DeleteExpense(int id) // удаления рассхода 
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expenses.Remove(expense);
            }
        }

        public List<Expense> GetExpenses() // функция для получения всех рассходов которые когда либо были
        {
            return expenses;
        }

        public decimal GetTotalBalance() // функция для получения  баланса юзера
        {
            return expenses.Sum(e => e.Amount);
        }
    }
}
