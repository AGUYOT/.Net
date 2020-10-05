using ClientAllocine.Model;
using ClientAllocine.Services;
using ClientAllocine.Services.Implementation;
using ClientAllocine.ViewModel.CompteModel;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAllocine.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<CompteViewModel>();
            SimpleIoc.Default.Register<CreationViewModel>();
            SimpleIoc.Default.Register<WSCompteService>();
            SimpleIoc.Default.Register<WSBingMapService>();
        }
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public CompteViewModel Compte => ServiceLocator.Current.GetInstance<CompteViewModel>();

        public CreationViewModel Creation => ServiceLocator.Current.GetInstance<CreationViewModel>();
    }
}
