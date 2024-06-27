using CostManagement.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CostManagement.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }
        public decimal Balance { get; set; }

        public MainViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
        }

        public void AddExpense(string description, decimal amount)
        {
            var expense = new Expense { Description = description, Amount = amount, Date = DateTime.Now };
            Expenses.Add(expense);
            UpdateBalance();
        }

        public void EditExpense(Expense expense)
        {
            // TO DO: implement edit logic
        }

        public void DeleteExpense(Expense expense)
        {
           