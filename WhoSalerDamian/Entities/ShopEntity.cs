using Microsoft.AspNetCore.Identity;

namespace WhoSalerDamian.Entities
{
    public class ShopEntity
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string ShopOwnerName { get; set; }
        public string ShopCity { get; set; }
        public string ShopRoad { get; set; }
        public string ShopZipCode { get; set; }
        public string ShopPhone { get; set; }
        public string  ShopEmail { get; set; }
        public IdentityUser OwnerUser { get; set; }
    }
}