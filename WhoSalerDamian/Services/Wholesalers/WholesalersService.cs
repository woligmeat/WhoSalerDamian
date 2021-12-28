using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WhoSalerDamian.Database;
using WhoSalerDamian.Entities;
using WhoSalerDamian.Models;

namespace WhoSalerDamian.Services.Wholesalers
{
    public class WholesalersService : IWholesalersServiceInterface
    {
        private AppDbContext _dbContext;
        private IHttpContextAccessor _httpContextAccessor;
        private UserManager<IdentityUser> _userManager;

        public WholesalersService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        
        public async Task Add(WholesalersModel wholesalersModel)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var entity = new WholesalersEntity
            {
                WholesalerName = wholesalersModel.WholesalerName,
                WholesalerCity = wholesalersModel.WholesalerCity,
                WholesalerEmail = wholesalersModel.WholesalerEmail,
                WholesalerPhone = wholesalersModel.WholesalerPhone,
                WholesalerRoad = wholesalersModel.WholesalerRoad,
                WholesalerOwnerName = wholesalersModel.WholesalerRoad,
                WholesalerZipCode = wholesalersModel.WholesalerZipCode,
                OwnerUser = currentUser
            };

            await _dbContext.Wholesalers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WholesalersEntity>> ListOwner(string name)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<WholesalersEntity> wholesalersQuery = _dbContext.Wholesalers;
            wholesalersQuery = wholesalersQuery.Where(x => x.OwnerUser == currentUser);

            if (!string.IsNullOrEmpty(name))
            {
                wholesalersQuery = wholesalersQuery.Where(x => x.WholesalerName.Contains(name));
            }

            var wholesalers = await wholesalersQuery.ToListAsync();

            return wholesalers;
        }

        public async Task<IEnumerable<WholesalersEntity>> ListUser(string name)
        {
            IQueryable<WholesalersEntity> wholesalersQuery = _dbContext.Wholesalers;
            
            if (!string.IsNullOrEmpty(name))
            {
                wholesalersQuery = wholesalersQuery.Where(x => x.WholesalerName.Contains(name));
            }

            var wholesalers = await wholesalersQuery.ToListAsync();

            return wholesalers;
        }
    }
}