using System.Collections.Generic;
using System.Threading.Tasks;
using WhoSalerDamian.Entities;
using WhoSalerDamian.Models;

namespace WhoSalerDamian.Services.Wholesalers
{
    public interface IWholesalersServiceInterface
    {
        Task Add(WholesalersModel wholesalersModel);
        Task<IEnumerable<WholesalersEntity>> ListOwner(string name);
        Task<IEnumerable<WholesalersEntity>> ListUser(string name);
    }
}