using ClientConvertisseurV1.Model;
using ClientConvertisseurV1.Service.Implementation;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitializeError();
            this.InitializeData();
        }

        private void InitializeError()
        {
            this.errorText.Text = "";
            this.errorText.Visibility = Visibility.Collapsed;
        }
        public async void InitializeData()
        {
            WSService service = WSService.GetInstance();
            var result = await service.GetDevisesAsync();
            this.deviseBox.DataContext = result.ToList();
            this.deviseBox.SelectedValue = 1;
        }

        private void ConvertCurrency_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(this.amountBox.Text))
            {
                int value;
                ConvertService service = new ConvertService();

                if(!int.TryParse(this.amountBox.Text, out value))
                {
                    this.errorText.Text = "La valeur que vous avez tapé est invalide !";
                    this.errorText.Visibility = Visibility.Visible;
                } else
                {
                    this.InitializeError();
                }
                Devise devise = (Devise)this.deviseBox.SelectedItem;
                double result = service.Convert(value, devise.Taux);
                this.convertedBox.Text = result.ToString();
            }
            else
            {
                this.errorText.Text = "Veuillez entrer une valeur !";
                this.errorText.Visibility = Visibility.Visible;
            }
        }
    }
}
