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

namespace ClientConvertisseurV2.ViewModel.AbstractModel
{
    public abstract class AbsractConvertViewModel : ViewModelBase
    {
        protected ObservableCollection<Devise> _comboBoxDevises;
        private IWSService _serviceWS;

        protected Devise _comboDeviseItem;
        protected string _errorLabelText;
        protected Visibility _errorLabelVisibility;
        protected string _resultText;

        public ICommand BtnSetConversion { get; private set; }

        public AbsractConvertViewModel()
        {
            _serviceWS = SimpleIoc.Default.GetInstance<WSService>();
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
            }
            catch (TimeoutException e)
            {
                ErrorLabelText = "Le Service de récupération des devises à mis trop de temps à répondre !";
                ErrorLabelVisibility = Visibility.Visible;
            }
            catch (Exception e)
            {
                ErrorLabelText = "Le Service de récupération des devises est injoignable !";
                ErrorLabelVisibility = Visibility.Visible;
            }
        }


        protected abstract void ActionSetConversion();

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
