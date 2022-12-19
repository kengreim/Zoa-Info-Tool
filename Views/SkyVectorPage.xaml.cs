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
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using ZOAHelper.ViewModels;
using ZOAHelper.Utils;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ZOAHelper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SkyVectorPage : Page
    {
        public SkyVectorViewModel ViewModel => (SkyVectorViewModel)DataContext;

        public SkyVectorPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<SkyVectorViewModel>();

            // Add enter key handler to the Route textbox only
            RouteTb.KeyDown += KeyHandlers.NewOnEnterCommandHandler(ViewModel.MakeUrlCommand);

            // Set focus on the Departure textbox once the page has fully loaded
            Loaded += (sender, e) =>
            {
                DepAirportTb.Focus(FocusState.Programmatic);
            };

            // Delete cookies to start fresh, but have to wait until CoreWebView2 object has started
            WebView.CoreWebView2Initialized += (o, e) => { WebView.CoreWebView2.CookieManager.DeleteAllCookies(); };
        }
    }
}
