using CostManagement.ViewModels;
using System.Windows;

namespace CostManagement.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).AddExpense(txtDescription.Text, decimal.Parse(txtAmount.Text));
            txtDescription.Clear();
            txtAmount.Clear();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).EditExpense((lvExpenses.SelectedItem as Expense));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).DeleteExpense((lvExpenses.SelectedItem as Expense));
        }
    }
}