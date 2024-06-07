using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// PlotControl.xaml 的交互逻辑
    /// </summary>
    public partial class PlotControl : UserControl
    {
        public ObservableCollection<double[]> DataSeries
        {
            get { return (ObservableCollection<double[]>)GetValue(DataSeriesProperty);}
            set { 
                SetValue(DataSeriesProperty, value);
                if (value != null)
                {
                    value.CollectionChanged += DataSeries_CollectionChanged;
                }
            }
        }
        public static readonly DependencyProperty DataSeriesProperty =
        DependencyProperty.Register("DataSeries", typeof(ObservableCollection<double[]>), typeof(PlotControl), new PropertyMetadata(new ObservableCollection<double[]>(), OnDataSeriesChanged));
        //public static readonly DependencyProperty DataSeriesProperty =
        // DependencyProperty.Register("DataSeries", typeof(ObservableCollection<double[]>), typeof(PlotControl), new PropertyMetadata(new ObservableCollection<double[]>()));
        private static void OnDataSeriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PlotControl control && e.NewValue is ObservableCollection<double[]> newSeries)
            {
                control.PlotData(newSeries);
            }
        }
        public PlotControl()
        {
            InitializeComponent();
        }
        private void DataSeries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PlotData(DataSeries);
        }
        private void PlotData(ObservableCollection<double[]> dataSeries)
        {
            var plt = wpfPlot.Plot;
            plt.Clear();

            if (dataSeries != null)
            {
                for (int i = 0; i < dataSeries.Count; i++)
                {
                    double[] data = dataSeries[i];
                    plt.AddSignal(data, label: $"Series {i + 1}");
                }
            }

            plt.Legend();
            wpfPlot.Refresh();
        }
    }
}
