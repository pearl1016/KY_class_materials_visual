using System;
using System.Collections.Generic;
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
using LiveCharts;
using LiveCharts.Wpf;

namespace _037_Livechart
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public SeriesCollection seriesCollection { get; set; } //속성 : prop [tab][tab]
        public string[] xMarks { get; set; }
        public Func<double, string> Values { get; set; }
            //double과 string으로 바꿔주는 함수는 Values를 가지고있다

        public MainWindow()
        {
            seriesCollection = new SeriesCollection
            {
                new LineSeries //LineSeries 선그래프 ,막대그래프라면 ColumnSeries그래프
                {
                    Title = "2020",
                    Values = new ChartValues<double> {3, 4, 5, 6, 7 }
                },
                new LineSeries
                {
                    Title = "2021",
                    Values = new ChartValues<double> {7, 5, 9, 1, 5 }
                },
                new LineSeries
                {
                    Title = "2022",
                    Values = new ChartValues<double> {6, 3, 2, 1, 10 }
                }
            };
            LineSeries s = new LineSeries();
            s.Title="2023";
            s.Values = new ChartValues<double> { 7, 9, 2, 8, 4 };
            seriesCollection.Add(s);

            xMarks = new string[] { "강", "조", "송", "허", "박" }; //5명의 값을 가지고있다
            Values = value => value.ToString("N"); //Lambda식
            DataContext = this; //꼭 있어야함

        }
    }
}
