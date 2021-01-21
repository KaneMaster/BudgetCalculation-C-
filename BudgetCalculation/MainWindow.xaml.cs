﻿using System;
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
        
        BudgetList bl = new BudgetList();

        public MainWindow()
        {
            InitializeComponent();
            Binding b = new Binding("DateStart");
            b.Source = bl.info;
            b.StringFormat = "dd.MM.yyyy";
            DateStartDP.SetBinding(TextBlock.TextProperty, b);
            b = new Binding("DateEnd");
            b.Source = bl.info;
            b.StringFormat = "dd.MM.yyyy";
            DateEndDP.SetBinding(TextBlock.TextProperty, b);
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
            bl.AddElement(new BudgetElement
            {
                Group = "Группа 1",
                SubGroup = "Подгруппа 1",
                Name = "1",
                Price = 10,
                CountGoods = 1,
                Units = "шт."
            });
            bl.AddElement(new BudgetElement
            {
                Group = "Группа 1",
                SubGroup = "Подгруппа 1",
                Name = "2",
                Price = 30,
                CountGoods = 1,
                Units = "шт."
            });
            bl.AddElement(new BudgetElement
            {
                Group = "Группа 1",
                SubGroup = "Подгруппа 2",
                Name = "33",
                Price = 10,
                CountGoods = 1,
                Units = "шт."
            });
            ReloadExpenseData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // bl.DelElement(ExpenseGrid.SelectedIndex);
            ReloadExpenseData();
        }
    }
}
