using ClientAllocine.Model;
using ClientAllocine.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAllocine.ViewModel
{
    public class CompteViewModel : ViewModelBase
    {
        private readonly IWSService<Compte> _wSService;
        public CompteViewModel()
        {
            _wSService = SimpleIoc.Default.GetInstance<IWSService<Compte>>();
        }
    }
}
