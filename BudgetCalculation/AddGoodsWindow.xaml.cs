using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BudgetCalculation
{

    /// <summary>
    /// Логика взаимодействия для AddGoodsWindow.xaml
    /// </summary>
    public partial class AddGoodsWindow : Window
    {
        BudgetModel model = new BudgetModel();
        BudgetElement product = new BudgetElement();

        List<ProductInfo> groups;
        List<ProductInfo> subGroups;
        List<ProductInfo> goods;


        public AddGoodsWindow()
        {            
            InitializeComponent();

            groups = model.GetGoups();
            subGroups = model.GetSubGroups();
            groupCB.ItemsSource = this.groups;
            subgroupCB.ItemsSource = this.subGroups;
        }



        private void subgroupCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goodsCB.ItemsSource = null;
            ComboBox cb = (ComboBox)sender;
            goods = model.GetGoods(Convert.ToInt32(cb.SelectedValue));
            goodsCB.ItemsSource = goods;
        }

        private void ButtonClickAddGood(object sender, RoutedEventArgs e)
        {

        }
    }
}
