using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BudgetCalculation
{
    class BudgetList : DependencyObject
    {
        public ListInfo info = new ListInfo {
            Caption = "11",
            LastSumm = 12.00d
        };
        public List<BudgetElement> elements = new List<BudgetElement>();
        double summList = 0;

        
        
        void Calculate()
        {
            summList = 0;
            foreach(BudgetElement element in elements)
            {
                summList += element.Summ;
            }
        } 

        public void AddElement(BudgetElement element)
        {
            elements.Add(element);
            Calculate();
        }

        public void DelElement(int index)
        {
            elements.RemoveAt(index);
            Calculate();
        }


    }
}
