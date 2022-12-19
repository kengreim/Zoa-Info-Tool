// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using ZOAHelper.Models;
using ZOAHelper.ViewModels;
using ZOAHelper.Utils;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ZOAHelper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TecPage : Page
    {
        public AliasRouteViewModel ViewModel => (AliasRouteViewModel)DataContext;
        public TecPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<AliasRouteViewModel>();

            RoutesListView.KeyDown += CopyRoute;
            
            // Add the Enter button handler to both text boxes
            DepAirportTb.KeyDown += KeyHandlers.NewOnEnterCommandHandler(ViewModel.MatchAliasRoutesCommand);
            ArrAirportTb.KeyDown += KeyHandlers.NewOnEnterCommandHandler(ViewModel.MatchAliasRoutesCommand);

            // Set focus on the Departure textbox once the page has fully loaded
            Loaded += (sender, e) => { DepAirportTb.Focus(FocusState.Programmatic); };
        }
        
        private void CopyRoute(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.C)
            {
                var selected = (AliasRoute)RoutesListView.SelectedItem;
                if (selected is not null)
                {
                    var dataPackage = new DataPackage();
                    dataPackage.SetText(selected.Route);
                    Clipboard.SetContent(dataPackage);
                }
            }
        }
    }
}
