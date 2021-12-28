using System.Collections.Generic;
using System.Threading.Tasks;
using WhoSalerDamian.Entities;
using WhoSalerDamian.Models;

namespace WhoSalerDamian.Services
{
    public interface IShopServiceInterface
    {
        Task Add(ShopModel shopModel);
        Task<IEnumerable<ShopEntity>> List(string name);
    }
}