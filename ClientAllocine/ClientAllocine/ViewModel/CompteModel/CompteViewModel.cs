using ClientAllocine.Model;
using ClientAllocine.Services;
using ClientAllocine.Services.Implementation;
using ClientAllocine.View;
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
using Windows.UI.Xaml.Controls;

namespace ClientAllocine.ViewModel.CompteModel
{
    public class CompteViewModel : AbstractCompteViewModel
    {
        private string _emailSearch;

        public ICommand BtnSearchCommand { get; private set; }
        public ICommand BtnAddCompteCommand { get; private set; }

        public CompteViewModel() : base()
        {
            BtnSearchCommand = new RelayCommand(ActionSearch);
            BtnAddCompteCommand = new RelayCommand(ActionAdd);
        }

        private void ActionAdd()
        {
            RootPage r = (RootPage)Window.Current.Content;
            SplitView sv = (SplitView)(r.Content);
            (sv.Content as Frame).Navigate(typeof(CreationPage));
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
                await _wSService.UpdateCompteAsync(CompteStored);
                var messageDialog = new MessageDialog("Le compte a bien été modifié !");

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
