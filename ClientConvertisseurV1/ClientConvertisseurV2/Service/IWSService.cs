using ClientConvertisseurV2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Service
{
    interface IWSService
    {
        Task<IEnumerable<Devise>> GetDevisesAsync();
    }
}
