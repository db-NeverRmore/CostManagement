using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CostManagement
{
    public partial class MainWindow : Window
    {

        private ExpenseManager expenseManager = new ExpenseManager(); // экземпляр 

        public MainWindow() // конструктор для нашего окна
        {
            InitializeComponent(); // инициализация всех компонентов приложения

            UpdateExpensesGrid(); // обновления таблиц 
            UpdateTotalBalance(); // обновляние баланса
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) // обрабатываются события при взаимодействия с кнопкой 
        {
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                expenseManager.AddExpense(DescriptionTextBox.Text, amount, DatePicker.SelectedDate ?? DateTime.Now);
                UpdateExpensesGrid();
                UpdateTotalBalance();
                ClearInputFields(); // очисткая поей ввода 
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }
        
        private void EditButton_Click(object sender, RoutedEventArgs e)// обработчик кнопки редактирования 
        {
            var button = sender as FrameworkElement;
            if (button != null && int.TryParse(button.Tag.ToString(), out int id))
            {
                var expense = expenseManager.GetExpenses().FirstOrDefault(exp => exp.Id == id);
                if (expense != null)
                {
                    DescriptionTextBox.Text = expense.Description;
                    AmountTextBox.Text = expense.Amount.ToString();
                    DatePicker.SelectedDate = expense.Date;

                    // Update the expense
                    expenseManager.EditExpense(id, DescriptionTextBox.Text, decimal.Parse(AmountTextBox.Text), DatePicker.SelectedDate ?? DateTime.Now);
                    UpdateExpensesGrid();
                    UpdateTotalBalance();
                    ClearInputFields();
                }
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e) // обработчик кнопки удаление 
        {
            var button = sender as FrameworkElement;
            if (button != null && int.TryParse(button.Tag.ToString(), out int id))
            {
                expenseManager.DeleteExpense(id);
                UpdateExpensesGrid();
                UpdateTotalBalance();
            }
        }

        private void UpdateExpensesGrid() // Обновление таблицы расходов
        {
            ExpensesDataGrid.ItemsSource = null; //очистка
            ExpensesDataGrid.ItemsSource = expenseManager.GetExpenses();
        }
        
        private void UpdateTotalBalance()
        {
            TotalBalanceTextBlock.Text = $"Total Balance: {expenseManager.GetTotalBalance():C}";
        }
   
        private void ClearInputFields()     // Очистка полей ввода в поле 
        {
            DescriptionTextBox.Text = string.Empty;
            AmountTextBox.Text = string.Empty;
            DatePicker.SelectedDate = null;
        }
    }
}
