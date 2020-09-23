using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Service;
using ClientConvertisseurV2.Service.Implementation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace ClientConvertisseurV2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Devise> _comboBoxDevises;
        private IWSService _serviceWS;
        private IConvertService _convertService;

        private string _montantEuros;
        private Devise _comboDeviseItem;
        private string _errorLabelText;
        private Visibility _errorLabelVisibility;
        private string _resultText;

        public ICommand BtnSetConversion { get; private set; }

        public MainViewModel()
        {
            _serviceWS = SimpleIoc.Default.GetInstance<WSService>();
            _convertService = SimpleIoc.Default.GetInstance<ConvertService>();
            InitializeData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        private async void InitializeData()
        {
            try
            {
                var result = await _serviceWS.GetDevisesAsync();
                this.ComboBoxDevises = new ObservableCollection<Devise>(result);
                ComboBoxDeviseItem = ComboBoxDevises.FirstOrDefault();
            } catch(TimeoutException e)
            {
                ErrorLabelText = "Le Service de récupération des devises à mis trop de temps à répondre !";
                ErrorLabelVisibility = Visibility.Visible;
            } catch(Exception e)
            {
                ErrorLabelText = "Le Service de récupération des devises est injoignable !";
                ErrorLabelVisibility = Visibility.Visible;
            }
        }


        private void ActionSetConversion()
        {
            if (!String.IsNullOrEmpty(MontantEuros))
            {
                double result;

                if (!_convertService.TryConvert(MontantEuros, ComboBoxDeviseItem.Taux, out result))
                {

                    ErrorLabelText = "La valeur que vous avez tapé est invalide !";
                    ErrorLabelVisibility = Visibility.Visible;
                    ResultText = "";
                }
                else
                {
                    ErrorLabelText = "";
                    ResultText = result.ToString();
                }
            }
            else
            {
                ErrorLabelText = "Veuillez entrer une valeur !";
                ErrorLabelVisibility = Visibility.Visible;
            }
        }

        public string MontantEuros { 
            get { return _montantEuros; }
            set {
                _montantEuros = value;
                RaisePropertyChanged();
            }
        }

        public Devise ComboBoxDeviseItem
        {
            get { return _comboDeviseItem; }
            set
            {
                _comboDeviseItem = value;
                RaisePropertyChanged();
            }
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

        public Visibility ErrorLabelVisibility
        {
            get { return _errorLabelVisibility; }
            set
            {
                _errorLabelVisibility = value;
                RaisePropertyChanged();
            }
        }

        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                RaisePropertyChanged();
            }
        }


        public ObservableCollection<Devise> ComboBoxDevises
        {
            get { return _comboBoxDevises; }
            set
            {
                _comboBoxDevises = value;
                RaisePropertyChanged();// Pour notifier de la modification de ses données
            }
        }
    }
}
