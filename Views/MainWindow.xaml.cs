// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using ZOAHelper.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ZOAHelper
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private Button? SelectedButton { get; set; }
        private SolidColorBrush UnselectedButtonBrush { get; set; }
        private SolidColorBrush SelectedButtonBrush { get; set; }
        private SolidColorBrush HoverButtonBrush { get; set; }
        private Dictionary<Button, Type> ButtonPageLookup { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();

            // Get base colors from Theme dictionary defined in App.xaml
            UnselectedButtonBrush = (SolidColorBrush)Application.Current.Resources["ButtonBackground"];
            SelectedButtonBrush = (SolidColorBrush)Application.Current.Resources["ButtonBackgroundPressed"];
            HoverButtonBrush = (SolidColorBrush)Application.Current.Resources["ButtonBackgroundPointerOver"];

            // Create lookup dictionary for buttons and associated main frame navigation pages
            ButtonPageLookup = new Dictionary<Button, Type>()
            {
                { datisBtn, typeof(DatisPage) },
                { rwRoutesBtn, typeof(RwRoutesPage) },
                { skyVectorBtn, typeof(SkyVectorPage) },
                { loaBtn, typeof(LoaPage) },
                { tecBtn, typeof(TecPage) },
                { chartsBtn, typeof(ChartsPage) },
                { codesBtn, typeof(CodesPage) }
            };

            // Set to default startup page
            mainFrame.Navigate(typeof(StartupPage));
        }

        private void NavBtn_Click(object sender, RoutedEventArgs e)
        {
            // Change the current selected button's color back to unselected and reset hover color
            if (SelectedButton is not null)
            {
                SelectedButton.Background = UnselectedButtonBrush;
                SelectedButton.Resources["ButtonBackgroundPointerOver"] = HoverButtonBrush;
            }

            // Set the new button's background and hover color and set to selected
            var btn = (Button)sender;
            btn.Background = SelectedButtonBrush;
            btn.Resources["ButtonBackgroundPointerOver"] = SelectedButtonBrush;
            SelectedButton = btn;

            // Navigate based on selected button. Contains check not necessary since buttons and lookup
            // dictionary are hardcoded, but it's another layer of exception protection
            if (ButtonPageLookup.ContainsKey(SelectedButton))
            {
                mainFrame.Navigate(ButtonPageLookup[SelectedButton], null, new SuppressNavigationTransitionInfo());
                //mainFrame.Navigate(ButtonPageLookup[SelectedButton]);
            }
        }
    }
}
