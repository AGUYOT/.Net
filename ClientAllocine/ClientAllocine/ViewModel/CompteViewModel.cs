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

namespace ClientAllocine.ViewModel
{
    public class CompteViewModel : ViewModelBase
    {
        private readonly IWSService<Compte> _wSService;
        private string _errorLabelText;
        private Compte _compteSearch;
        private string _emailSearch;
        protected Visibility _errorLabelVisibility;

        public ICommand BtnSearchCommand { get; private set; }
        public ICommand BtnClearCompteCommand { get; private set; }
        public ICommand BtnModifyCompteCommand { get; private set; }

        public CompteViewModel()
        {
            _wSService = SimpleIoc.Default.GetInstance<WSCompteService>();
            BtnSearchCommand = new RelayCommand(ActionSearch);
            BtnClearCompteCommand = new RelayCommand(ActionClear);
            BtnModifyCompteCommand = new RelayCommand(ActionUpdate);
        }

        private async void ActionSearch()
        {
            Compte result = await _wSService.GetByStringAsync(EmailSearch);
            if(result != null)
            {
                CompteSearch = result;
                ErrorLabelText = "";
                ErrorLabelVisibility = Visibility.Collapsed;
            }
            else
            {
                ErrorLabelText = "Compte non trouvé !";
                ErrorLabelVisibility = Visibility.Visible;
            }
        }

        private async void ActionUpdate()
        {
            try
            {
                await _wSService.UpdateCompteAsync(CompteSearch);
                var messageDialog = new MessageDialog("Le compte a bien été modifié !");

                messageDialog.Commands.Add(new UICommand(
                    "Close",
                    null));

                messageDialog.DefaultCommandIndex = 0;
                messageDialog.CancelCommandIndex = 1;

                // Show the message dialog
                await messageDialog.ShowAsync();
            } catch(Exception)
            {
                ErrorLabelText = "Echec de l'update du compte";
                ErrorLabelVisibility = Visibility.Visible;
            }
        }

        private void ActionClear()
        {
            CompteSearch = null;
        }

        public string ErrorLabelText
        {
            get { return _errorLabelText; }
            set
            {
                _errorLabelText = value;
                RaisePropertyChanged();
            }
        }
        
        public Compte CompteSearch
        {
            get { return _compteSearch; }
            set
            {
                _compteSearch = value;
                RaisePropertyChanged();
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
        
        public Visibility ErrorLabelVisibility
        {
            get { return _errorLabelVisibility; }
            set
            {
                _errorLabelVisibility = value;
                RaisePropertyChanged();
            }
        }
    }
}
