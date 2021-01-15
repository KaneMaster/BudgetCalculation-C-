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
    public class ProductInfo
    {

        public int Id { get; set; }
        public string Name { get; set; }

    }
    /// <summary>
    /// Логика взаимодействия для AddGoodsWindow.xaml
    /// </summary>
    public partial class AddGoodsWindow : Window
    {
        BudgetElement product = new BudgetElement();

        List<ProductInfo> groups = new List<ProductInfo> {
            new ProductInfo { Id = 1, Name = "Группа 1" },
            new ProductInfo { Id = 2, Name = "Группа 2" },
        };
        List<ProductInfo> subGroups = new List<ProductInfo>{
            new ProductInfo { Id = 1, Name = "Подгруппа 11" },
            new ProductInfo { Id = 2, Name = "Подгруппа 12" },
        };
        List<ProductInfo> products = new List<ProductInfo>{
            new ProductInfo { Id = 1, Name = "Товар 1" },
            new ProductInfo { Id = 2, Name = "Товар 2" },
        };

        public AddGoodsWindow()
        {            
            InitializeComponent();
        }


    }
}
