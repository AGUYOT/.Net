using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Service;
using ClientConvertisseurV2.Service.Implementation;
using ClientConvertisseurV2.ViewModel.AbstractModel;
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
    public class RevertViewModel : AbsractConvertViewModel
    {
        private IConvertService _convertService;

        private string _montantDevise;

        public RevertViewModel() :base()
        {
            _convertService = SimpleIoc.Default.GetInstance<ConvertService>();
        }


        protected override void ActionSetConversion()
        {
            if (!String.IsNullOrEmpty(MontantDevise))
            {
                double result;

                if (!_convertService.TryConvert(MontantDevise, 1/ComboBoxDeviseItem.Taux, out result))
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

        public string MontantDevise { 
            get { return _montantDevise; }
            set {
                _montantDevise = value;
                RaisePropertyChanged();
            }
        }
    }
}
