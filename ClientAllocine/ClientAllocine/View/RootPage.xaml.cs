using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace ClientAllocine.View
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
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame myFrame = this.RootView.Content as Frame;
            if (myFrame.CanGoBack)
            {
                myFrame.GoBack();
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            RootView.IsPaneOpen = !RootView.IsPaneOpen;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            (RootView.Content as Frame).Navigate(typeof(MainPage));
        }

        private void Compte_Click(object sender, RoutedEventArgs e)
        {
            (RootView.Content as Frame).Navigate(typeof(ComptePage));
        }
    }
}
