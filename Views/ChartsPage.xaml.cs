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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using ZOAHelper.Utils;
using ZOAHelper.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ZOAHelper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChartsPage : Page
    {
        public ChartViewModel ViewModel => (ChartViewModel)DataContext;

        public ChartsPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<ChartViewModel>();

            AirportTb.KeyDown += KeyHandlers.NewOnEnterCommandHandler(ViewModel.FetchChartsCommand);

            // Set focus on the Airport textbox once the page has fully loaded
            Loaded += (sender, e) => { AirportTb.Focus(FocusState.Programmatic); };
        }

        public void PdfButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            string url = btn.Tag as string;
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }
    }
}
