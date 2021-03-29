using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetCalculation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BudgetList bl;

        public MainWindow()
        {
            InitializeComponent();
            bl = new BudgetList();            
        }

        /// <summary>
        /// Reload information about expenses 
        /// </summary>
        private void ReloadExpenseData()
        {
            ExpenseGrid.ItemsSource = null;
            ExpenseGrid.ItemsSource = bl.elements;            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // bl.DelElement(ExpenseGrid.SelectedIndex);
            
            ReloadExpenseData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime d1 = new DateTime(2021, 02, 01);
            DateTime d2 = new DateTime(2021, 03, 01);
            bl.GetData(d1, d2);
            ReloadExpenseData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddGoodsWindow addWindow = new AddGoodsWindow();
            addWindow.ShowDialog();
        }
    }
}
