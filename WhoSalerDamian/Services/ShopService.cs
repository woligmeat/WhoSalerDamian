using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WhoSalerDamian.Database;
using WhoSalerDamian.Entities;
using WhoSalerDamian.Models;

namespace WhoSalerDamian.Services
{
    public class ShopService : IShopServiceInterface
    {
        private AppDbContext _dbContext;
        private IHttpContextAccessor _httpContextAccessor;
        private UserManager<IdentityUser> _userManager;

        public ShopService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        
        public async Task Add(ShopModel shopModel)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var entity = new ShopEntity
            {
                ShopName = shopModel.ShopName,
                ShopCity = shopModel.ShopCity,
                ShopEmail = shopModel.ShopEmail,
                ShopPhone = shopModel.ShopPhone,
                ShopRoad = shopModel.ShopRoad,
                ShopOwnerName = shopModel.ShopOwnerName,
                ShopZipCode = shopModel.ShopZipCode,
                OwnerUser = currentUser
            };

            await _dbContext.Shops.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShopEntity>> List(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<ShopEntity> shopQuery = _dbContext.Shops;
            shopQuery = shopQuery.Where(x => x.OwnerUser == currentUser);
            if (!string.IsNullOrEmpty(name))
            {
                shopQuery = shopQuery.Where(x => x.ShopName.Contains(name));
            }

            var shops = await shopQuery.ToListAsync();

            return shops;
        }
    }
}