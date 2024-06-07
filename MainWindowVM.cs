using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Base;

namespace WpfApp1
{
    public class MainWindowVM : BaseViewModel
    {
        private ObservableCollection<double[]> _plotData;

        public ObservableCollection<double[]> PlotData
        {
            get { return _plotData; }
            set
            {
                if (_plotData != value)
                {
                    _plotData = value;
                    OnpropertyChanged(nameof(PlotData));
                }
            }
        }
        public ICommand UpdateDataCommand { get; }

        public MainWindowVM()
        {
            PlotData = new ObservableCollection<double[]>();
            //{
            //    new double[] {1, 2, 3, 4, 5},
            //    new double[] {2, 4, 6, 8, 10},
            //    new double[] {5, 10, 15, 20, 25},
            //    new double[] {3, 6, 9, 12, 15}
            //};
            UpdateDataCommand = new RelayCommand(_ => UpdateData());
        }



        private void UpdateData()
        {
            Random rand = new Random();
            var newPlotData = new ObservableCollection<double[]>();
            //PlotData.Clear();

            for (int i = 0; i < 4; i++)
            {
                double[] newData = new double[5];
                for (int j = 0; j < 5; j++)
                {
                    newData[j] = rand.NextDouble() * 10;
                }
                newPlotData.Add(newData);
            }
            PlotData = newPlotData;
        }
        //    private void UpdateData()
        //{
        //    Random rand = new Random();
        //    var updatedData = new ObservableCollection<double[]>();

        //    foreach (var series in PlotData)
        //    {
        //        var dataList = new List<double>(series)
        //        {
        //            rand.NextDouble() * 10 // 增加一个随机点
        //        };
        //        updatedData.Add(dataList.ToArray());
        //    }

        //    PlotData = updatedData;
        //}
    }
}
