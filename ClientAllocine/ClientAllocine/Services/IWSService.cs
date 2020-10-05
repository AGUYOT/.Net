using ClientAllocine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAllocine.Services
{
    public interface IWSService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByStringAsync(string param);
        Task UpdateCompteAsync(Compte compte);
    }
}
