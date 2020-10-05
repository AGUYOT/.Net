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
using Windows.UI.Xaml;

namespace ClientAllocine.ViewModel
{
    public abstract class AbstractCompteViewModel : ViewModelBase
    {
        protected readonly IWSService<Compte> _wSService;
        protected string _errorLabelText;
        protected Compte _compteStored;
        protected Visibility _errorLabelVisibility;

        public ICommand BtnClearCompteCommand { get; private set; }
        public ICommand BtnModifyCompteCommand { get; private set; }

        public AbstractCompteViewModel()
        {
            _wSService = SimpleIoc.Default.GetInstance<WSCompteService>();
            BtnClearCompteCommand = new RelayCommand(ActionClear);
            BtnModifyCompteCommand = new RelayCommand(ActionUpdate);
        }

        protected abstract void ActionUpdate();

        private void ActionClear()
        {
            CompteStored = null;
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

        public Compte CompteStored
        {
            get { return _compteStored; }
            set
            {
                _compteStored = value;
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
