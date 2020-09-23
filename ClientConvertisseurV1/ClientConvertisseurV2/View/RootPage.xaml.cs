using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientConvertisseurV2.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage(Frame frame)
        {
            this.InitializeComponent();
            RootView.Content = frame;
            (RootView.Content as Frame).Navigate(typeof(MainPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            RootView.IsPaneOpen = !RootView.IsPaneOpen;
        }

        private void MenuButtonHome_Click(object sender, RoutedEventArgs e)
        {
            (RootView.Content as Frame).Navigate(typeof(MainPage));
        }

        private void MenuButtonPage_Click(object sender, RoutedEventArgs e)
        {
            (RootView.Content as Frame).Navigate(typeof(RevertPage));
        }
    }
}
