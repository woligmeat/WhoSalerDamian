using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhoSalerDamian.Models;
using WhoSalerDamian.Services.Wholesalers;

namespace WhoSalerDamian.Controllers
{
    public class Wholesalers : Controller
    {
        private readonly IWholesalersServiceInterface _wholesalersServiceInterface;
        
        public Wholesalers(IWholesalersServiceInterface wholesalersServiceInterface)
        {
            _wholesalersServiceInterface = wholesalersServiceInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(WholesalersModel model)
        {
            await _wholesalersServiceInterface.Add(model);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListOwner(string name)
        {
            var wholesalers = await _wholesalersServiceInterface.ListOwner(name);
            return View(wholesalers);
        }
        
        [HttpGet]
        public async Task<IActionResult> ListUser(string name)
        {
            var wholesalers = await _wholesalersServiceInterface.ListUser(name);
            return View(wholesalers);
        }
    }
}