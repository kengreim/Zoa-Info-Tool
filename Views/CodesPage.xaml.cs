// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using ZOAHelper.ViewModels;
using ZOAHelper.Utils;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ZOAHelper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CodesPage : Page
    {
        public IcaoCodesViewModel ViewModel => (IcaoCodesViewModel)DataContext;
        public CodesPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<IcaoCodesViewModel>();

            AircraftTb.KeyDown += KeyHandlers.NewOnEnterCommandHandler(ViewModel.LookupAircraftCommand);
            AirlineTb.KeyDown += KeyHandlers.NewOnEnterCommandHandler(ViewModel.LookupAirlineCommand);
            AirportTb.KeyDown += KeyHandlers.NewOnEnterCommandHandler(ViewModel.LookupAirportCommand);
        }
    }
}