﻿using ClientConvertisseurV2.Service;
using ClientConvertisseurV2.Service.Implementation;
using ClientConvertisseurV2.ViewModel.AbstractModel;
using GalaSoft.MvvmLight.Ioc;
using System;
using Windows.UI.Xaml;

namespace ClientConvertisseurV2.ViewModel
{
    public class MainViewModel : AbsractConvertViewModel
    {
        private IConvertService _convertService;

        private string _montantEuros;

        public MainViewModel()
        {
            _convertService = SimpleIoc.Default.GetInstance<ConvertService>();
        }

        protected override void ActionSetConversion()
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
    }
}
