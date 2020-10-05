using ClientAllocine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAllocine.Services
{
    public interface IWSBingMapService
    {
        Task<Rootobject> GetCoordinates(Compte compte);
    }
}
