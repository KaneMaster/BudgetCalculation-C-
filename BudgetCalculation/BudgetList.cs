using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BudgetCalculation
{
    class BudgetList : DependencyObject
    {
        private BudgetModel model = new BudgetModel();
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

        public void GetData(DateTime d1, DateTime d2)
        {
            elements = model.GetExpensesList(d1, d2);
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
