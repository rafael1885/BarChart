using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BarChart
{
    /// <summary>
    /// Interaction logic for BarChart.xaml
    /// </summary>
    public partial class Bar : UserControl, INotifyPropertyChanged
    {
        private double _value;
       
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public double Value
    {
            get { return _value; }
            set
            {
                _value = value;
                UpdateBarHeigth();
                NotifyPropertyChanged("Value");
            }
        }
        
        private double maxValue;
        public double MaxValue
        {
           get { return maxValue; }
           set
            {
                maxValue = value;
                UpdateBarHeigth();
                NotifyPropertyChanged("MaxValue");
            }
        }
        private double barHeigth;
        public double BarHeigth
        {
            get { return barHeigth; }
            private set { barHeigth = value; NotifyPropertyChanged("BarHeigth"); }
        }
        private Brush color;
        public Brush Color
        {
            get { return color; }
            set { color = value; NotifyPropertyChanged("Color"); }

        }
        
        private void UpdateBarHeigth()
        {
            if(maxValue > 0)
            {
                var percent = (_value *100) / maxValue;
                BarHeigth= (percent * this.ActualHeight) / 100;
            }
        }


       
        public Bar()
        {
            InitializeComponent();
            this.DataContext = this;
            Color = Brushes.Black;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateBarHeigth();

        }
        
        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateBarHeigth();
        }
    }
}
