using ClientConvertisseurV2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Service
{
    public interface IWSService
    {
        Task<IEnumerable<Devise>> GetDevisesAsync();
    }
}
