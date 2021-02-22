using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BudgetCalculation
{
    class BudgetElement : DependencyObject
    {

        public static readonly DependencyProperty priceProperty, groupProperty, subGroupProperty, nameProperty,
            countGoodsProperty, UnitsProperty, summProperty, idProperty;


        static BudgetElement()
        {
            idProperty = DependencyProperty.Register("Id", typeof(int), typeof(BudgetElement), new PropertyMetadata(0));
            priceProperty = DependencyProperty.Register("Price", typeof(double), typeof(BudgetElement), new PropertyMetadata(0d, new PropertyChangedCallback(SummCalculate)));
            groupProperty = DependencyProperty.Register("Group", typeof(string), typeof(BudgetElement), new PropertyMetadata(String.Empty));
            subGroupProperty = DependencyProperty.Register("SubGroup", typeof(string), typeof(BudgetElement), new PropertyMetadata(String.Empty));
            nameProperty = DependencyProperty.Register("Name", typeof(string), typeof(BudgetElement), new PropertyMetadata(String.Empty));
            countGoodsProperty = DependencyProperty.Register("CountGoods", typeof(int), typeof(BudgetElement), new PropertyMetadata(1, new PropertyChangedCallback(SummCalculate)));            
            UnitsProperty = DependencyProperty.Register("Units", typeof(string), typeof(BudgetElement), new PropertyMetadata(String.Empty));
            summProperty = DependencyProperty.Register("Summ", typeof(double), typeof(BudgetElement), new PropertyMetadata(0d));
        }

        private static void SummCalculate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(summProperty, (double)d.GetValue(priceProperty) * (int)d.GetValue(countGoodsProperty));            
        }

        /// <summary>
        /// Price of product
        /// </summary>
        public double Price
        {
            get => (double)GetValue(priceProperty);
            set
            {
                value = (value < 0) ? 0 : value;
                SetValue(priceProperty, value);
            }
        }

        /// <summary>
        /// Count of products
        /// </summary>
        public int CountGoods
        {
            get => (int)GetValue(countGoodsProperty);
            set
            {
                value = (value < 0) ? 0 : value;
                SetValue(countGoodsProperty, value);
            }
        }

        /// <summary>
        /// Group of product
        /// </summary>
        public string Group
        {
            get => GetValue(groupProperty).ToString(); 
            set => SetValue(groupProperty, value); 
        }

        /// <summary>
        /// Subgroup of product
        /// </summary>
        public string SubGroup
        {
            get => GetValue(subGroupProperty).ToString(); 
            set => SetValue(subGroupProperty, value); 
        }

        /// <summary>
        /// Name of product
        /// </summary>
        public string Name
        {
            get => GetValue(nameProperty).ToString();
            set => SetValue(nameProperty, value);
        }

        /// <summary>
        /// units of product
        /// </summary>
        public string Units
        {
            get => GetValue(UnitsProperty).ToString();
            set => SetValue(UnitsProperty, value);
        }


        public double Summ
        {
            get => (double)GetValue(summProperty);
            set => SetValue(summProperty, value);
        }

        public int Id
        {
            get => (int)GetValue(idProperty);
            set => SetValue(idProperty, value);
        }




    }
}
