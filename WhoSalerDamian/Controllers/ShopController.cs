using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhoSalerDamian.Models;
using WhoSalerDamian.Services;

namespace WhoSalerDamian.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopServiceInterface _shopServiceInterface;
        
        public  ShopController(IShopServiceInterface shopServiceInterface)
        {
            _shopServiceInterface = shopServiceInterface;
        }
        
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ShopModel shopModel)
        {
            await _shopServiceInterface.Add(shopModel);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            var products = await _shopServiceInterface.List(name);
            return View(products);
        }
        
        
    }
}