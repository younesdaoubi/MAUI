using Microsoft.Maui.Controls;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;


namespace MyApp.ViewModel
{


    public partial class ChartsViewModel : BaseViewModel
    {

        [ObservableProperty]
        private Chart myObservableChart;

        public ChartsViewModel()
        {
            RefreshPage();
        }



        public void RefreshPage()
        {
            var entries = Globals.MyFelines
                .Where(f => f.TopSpeed.HasValue && !string.IsNullOrWhiteSpace(f.Origin))
                .GroupBy(f => f.Origin)
                .Select(g => new ChartEntry((float)g.Average(f => f.TopSpeed.Value))
                {
                    Label = g.Key,
                    ValueLabel = g.Average(f => f.TopSpeed.Value).ToString("F1"),
                    Color = SKColor.Parse(GetColorForOrigin(g.Key))
                }).ToArray();

            MyObservableChart = new RadarChart
            {
                Entries = entries,
                BackgroundColor = SKColors.White,
            };
        }



        private string GetColorForOrigin(string origin)
        {
            // Assigner des couleurs  
            return origin switch
            {
                "Africa" => "#FF5733",
                "Asia" => "#33FF57",
                "America" => "#3357FF",
                "Europe" => "#FF33A6",
                _ => "#b455b6",  
            };
        }


        /*
           [ObservableProperty]
    public Chart myObservableChart = new RadarChart();

    ChartEntry[] entries = new[]
       {
           new ChartEntry(51)
           {
               Label = "S1",
               ValueLabel="51",
               Color = SKColor.Parse("#b455b6")
           },
            
           
           new ChartEntry(24)
           {
               Label = "S8",
               ValueLabel="24",
               Color = SKColor.Parse("#b455b6")
           },
           new ChartEntry(48)
           {
               Label = "S9",
               ValueLabel="48",
               Color = SKColor.Parse("#b455b6")
           },
           new ChartEntry(87)
           {
               Label = "S10",
               ValueLabel="87",
               Color = SKColor.Parse("#b455b6")
           }
       };
    public DetailsViewModel()
    {}

    public void RefreshPage()
    {
        Chart myChart = new RadarChart
        {
            Entries = entries
        };

        MyObservableChart = myChart;
    }
     */




        /*public .()
{
    UpdateChart();
     }*/

        /*private void UpdateChart()
{
    var entries = MyObservableBorn
       .Select((born, index) => new ChartEntry(float.Parse(MyObservableAge[index]))
       {
           Label = DateTime.ParseExact(born, "ddMMyyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"),
           ValueLabel = MyObservableAge[index],
           Color = SKColor.Parse("#FF5733") // Couleur fixe pour tous les éléments du graphique
       }).ToArray();*/


        /*   
            MyObservableChart = new LineChart
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                BackgroundColor = SKColors.White,
                LineSize = 8,
                ValueLabelOrientation = Orientation.Horizontal,
                PointMode = PointMode.Circle,
                PointSize = 18
            };
        }*/

    }
}
    


    
     