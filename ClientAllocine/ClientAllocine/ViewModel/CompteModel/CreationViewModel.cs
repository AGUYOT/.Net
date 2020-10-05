using ClientAllocine.Model;
using ClientAllocine.Services;
using ClientAllocine.Services.Implementation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace ClientAllocine.ViewModel.CompteModel
{
    public class CreationViewModel : AbstractCompteViewModel
    {
        private string _emailSearch;

        public CreationViewModel() : base()
        {
            CompteStored = new Compte();
        }
        private async void ActionSearch()
        {
            Compte result = await _wSService.GetByStringAsync(EmailSearch);
            if (result != null)
            {
                CompteStored = result;
                ErrorLabelText = "";
                ErrorLabelVisibility = Visibility.Collapsed;
            }
            else
            {
                ErrorLabelText = "Compte non trouvé !";
                ErrorLabelVisibility = Visibility.Visible;
            }
        }

        protected override async void ActionUpdate()
        {
            try
            {
                Compte result = await _wSService.CreateCompteAsync(CompteStored);
                var messageDialog = new MessageDialog($"Le compte {result.Nom} localisé à ({result.Longitude},{result.Latitude}) a bien été créé !");

                messageDialog.Commands.Add(new UICommand(
                    "Close",
                    null));

                messageDialog.DefaultCommandIndex = 0;
                messageDialog.CancelCommandIndex = 1;

                // Show the message dialog
                await messageDialog.ShowAsync();
            }
            catch (Exception)
            {
                ErrorLabelText = "Echec de l'update du compte";
                ErrorLabelVisibility = Visibility.Visible;
            }
        }

        public string EmailSearch
        {
            get { return _emailSearch; }
            set
            {
                _emailSearch = value;
                RaisePropertyChanged();
            }
        }
    }
}
