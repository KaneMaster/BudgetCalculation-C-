using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BudgetCalculation
{
    class ListInfo : DependencyObject
    {
        private readonly DependencyProperty dateStartProperty, dateEndProperty, captionProperty, lastSummProperty, idProperty;

        public ListInfo()
        {
            idProperty = DependencyProperty.Register("Id", typeof(int), typeof(ListInfo), new PropertyMetadata(0));
            dateStartProperty = DependencyProperty.Register("DateStart", typeof(DateTime), typeof(ListInfo), new PropertyMetadata(DateTime.Now));
            dateEndProperty = DependencyProperty.Register("DateEnd", typeof(DateTime), typeof(ListInfo), new PropertyMetadata(DateTime.Now));
            captionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(ListInfo), new PropertyMetadata(String.Empty));
            lastSummProperty = DependencyProperty.Register("LastSumm", typeof(double), typeof(ListInfo), new PropertyMetadata(0d, null, new CoerceValueCallback(ValidLastSum)));
        }

        public ListInfo(int id, DateTime dateStart, DateTime dateEnd, string capt, double summ) : this()
        {
            this.Id = id;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.Caption = capt;
            this.LastSumm = summ;
        }

        public DateTime DateStart
        {
            get => (DateTime)GetValue(dateStartProperty);
            set => SetValue(dateStartProperty, value);
        }

        public DateTime DateEnd
        {
            get => (DateTime)GetValue(dateEndProperty);
            set => SetValue(dateEndProperty, value);
        }

        public string Caption
        {
            get => GetValue(captionProperty).ToString();
            set => SetValue(captionProperty, value);
        }

        public double LastSumm
        {
            get => (double)GetValue(lastSummProperty);
            set => SetValue(lastSummProperty, value);
        }

        public int Id
        {
            get => (int)GetValue(idProperty);
            set => SetValue(idProperty, value);
        }

        private object ValidLastSum(DependencyObject d, object baseValue)
        {
            double val = (double)baseValue;
            return (val < 0) ? 0f : Math.Round(val, 2);
        }

    }
}
