using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetCalculation
{
    class BudgetElement : Object
    {
        private double price;
        private int countGoods;
        private double summ;

        public string Group { set; get; }
        public string SubGroup { set; get; }
        public string Name { set; get; }        
        public double Price {private set => price = (value < 0) ? 0 : value; get => price;}
        public bool IsExpense { set; get; }
        public int CountGoods { get; }
        public double Summ { get; }

        public BudgetElement( string group, string subGroup, string Name, double price, bool isExpense, int countGoods)
        {

        }


    }
}
