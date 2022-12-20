using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using ZOAHelper.Models;
using ZOAHelper.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ZOAHelper.ViewModels
{
    public partial class ChartViewModel : ObservableObject
    {
        private MemoryCache ChartsCache { get; set; }
        private MemoryCacheEntryOptions CacheEntryOptions { get; set; }
        
        [ObservableProperty]
        private string airport;

        public ObservableGroupedCollection<ChartType, Chart> ChartsGrouped { get; private set; }

        private IChartService ChartFetcher { get; set; }

        public ChartViewModel(IChartService chartFetcher)
        {
            ChartFetcher = chartFetcher;
            ChartsGrouped = new ObservableGroupedCollection<ChartType, Chart>();

            // Create cache with default TTL from Constants model, which is 24 hours
            ChartsCache = new MemoryCache(new MemoryCacheOptions());
            CacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Constants.CacheTtlSeconds)
            };
        }

        [RelayCommand]
        private async void FetchCharts()
        {   
            // Check cache first so we don't have to re-fetch if not necessary
            if (ChartsCache.TryGetValue(Airport, out ObservableGroupedCollection<ChartType, Chart> charts))
            {
                ChartsGrouped = charts;
                OnPropertyChanged(nameof(ChartsGrouped));
            }
            else
            {
                try
                {   
                    // Fetch charts
                    List<Chart> newCharts = await ChartFetcher.FetchChartsAsync(Airport);

                    // Group the new charts by Chart Type
                    var grouped = newCharts.GroupBy(static x => x.Type).OrderBy(static g => g.Key);
                    ChartsGrouped = new ObservableGroupedCollection<ChartType, Chart>(grouped);
                    OnPropertyChanged(nameof(ChartsGrouped));

                    // Cache result
                    ChartsCache.Set(Airport, ChartsGrouped, CacheEntryOptions);
                }
                catch (Exception)
                {
                    // Do nothing on exception right now
                    // Todo: maybe create popup?
                }
            }
        }
    }
}
