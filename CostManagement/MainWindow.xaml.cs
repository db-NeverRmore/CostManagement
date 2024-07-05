using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CostManagement
{
    public partial class MainWindow : Window
    {
        private ExpenseManager expenseManager = new ExpenseManager();

        public MainWindow()
        {
            InitializeComponent(); // need to fix cuz idk

            UpdateExpensesGrid();
            UpdateTotalBalance();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                expenseManager.AddExpense(DescriptionTextBox.Text, amount, DatePicker.SelectedDate ?? DateTime.Now);
                UpdateExpensesGrid();
                UpdateTotalBalance();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            if (button != null && int.TryParse(button.Tag.ToString(), out int id))
            {
                var expense = expenseManager.GetExpenses().FirstOrDefault(exp => exp.Id == id);
                if (expense != null)
                {
                    DescriptionTextBox.Text = expense.Description; //  need to fix cuz idk
                    AmountTextBox.Text = expense.Amount.ToString(); 
                    DatePicker.SelectedDate = expense.Date;
                    expenseManager.DeleteExpense(id);
                    UpdateExpensesGrid();
                    UpdateTotalBalance();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            if (button != null && int.TryParse(button.Tag.ToString(), out int id))
            {
                expenseManager.DeleteExpense(id);
                UpdateExpensesGrid();
                UpdateTotalBalance();
            }
        }

        private void UpdateExpensesGrid()
        {
            ExpensesDataGrid.ItemsSource = null;
            ExpensesDataGrid.ItemsSource = expenseManager.GetExpenses();
        }

        private void UpdateTotalBalance()
        {
            TotalBalanceTextBlock.Text = $"Total Balance: {expenseManager.GetTotalBalance():C}";
        }
    
}
