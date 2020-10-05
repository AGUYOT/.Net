using ClientAllocine.Model;
using ClientAllocine.Services;
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
            SimpleIoc.Default.Register<IWSService<Compte>>();
        }
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public CompteViewModel Main => ServiceLocator.Current.GetInstance<CompteViewModel>();
    }
}
