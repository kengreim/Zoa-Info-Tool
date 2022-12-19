using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.ViewModels
{
    public partial class SkyVectorViewModel : ObservableObject
    {
        [ObservableProperty]
        private string departureAirport;
        
        [ObservableProperty]
        private string arrivalAirport;

        [ObservableProperty]
        private string route;

        [ObservableProperty]
        private string url;

        public SkyVectorViewModel()
        {
            Url = Constants.SkyVectorBaseUrl;
        }

        [RelayCommand]
        private void MakeUrl()
        {
            Url = string.Join(" ", new string[] { Constants.SkyVectorBaseUrl, departureAirport, route, arrivalAirport });
        }
    }
}
