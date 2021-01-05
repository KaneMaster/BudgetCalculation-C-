using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetCalculation
{
    class BudgetElement : Object
    {
        private double price = 0;
        private int countGoods = 0;
        private double summ = 0;

        public string Group { set; get; }
        public string SubGroup { set; get; }
        public string Name { set; get; }        
        public double Price { 
            set {
                price = (value < 0) ? 0 : value;
                summ = price * countGoods;
            }
            get => price;
        } 
        public bool IsExpense { set; get; }
        public int CountGoods {
            set
            {
                countGoods = (value < 0) ? 0 : value;
                summ = price * countGoods;
            }
            get => countGoods;
        }
        public double Summ { get => summ; }   
        public string edIzm { get; set; }
    }
}
