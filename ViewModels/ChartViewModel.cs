using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZOAHelper.Models;
using ZOAHelper.Services.Interfaces;

namespace ZOAHelper.ViewModels
{
    public partial class ChartViewModel : ObservableObject
    {
        [ObservableProperty]
        private string airport;

        public ObservableCollection<Chart> Charts;

        //[ObservableProperty]
        //private ObservableGroupedCollection<ChartType, Chart> chartsGrouped;

        //[ObservableProperty]
        //private CollectionViewSource chartsGroupedCVS;

        private IChartService ChartFetcher { get; set; }

        public ChartViewModel(IChartService chartFetcher)
        {
            ChartFetcher = chartFetcher;
            Charts = new ObservableCollection<Chart>();
            //ChartsGrouped = new ObservableGroupedCollection<ChartType, Chart>();
            //ChartsGroupedCVS = new CollectionViewSource
            //{
            //    IsSourceGrouped = true,
            //    Source = ChartsGrouped,
            //};
        }

        [RelayCommand]
        private async void FetchCharts()
        {
            try
            {
                List<Chart> newCharts = await ChartFetcher.FetchChartsAsync(Airport);
                Charts.Clear();
                foreach (var chart in newCharts)
                {
                    Charts.Add(chart);
                }
                
                //var groups = Charts.GroupBy(x => x.Type).OrderBy(x => x.Key).ToList();
                //ChartsGrouped = groups;
            }
            catch (Exception)
            {
                // Do nothing on exception right now
                // Todo: maybe create popup?
            }
        }
    }
}
