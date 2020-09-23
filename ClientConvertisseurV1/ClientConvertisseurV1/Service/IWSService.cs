using ClientConvertisseurV1.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Service
{
    interface IWSService
    {
        Task<IEnumerable<Devise>> GetDevisesAsync();
    }
}
