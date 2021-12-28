using Microsoft.AspNetCore.Identity;

namespace WhoSalerDamian.Entities
{
    public class WholesalersEntity
    {
        public int Id { get; set; }
        public string WholesalerName { get; set; }
        public string WholesalerOwnerName { get; set; }
        public string WholesalerCity { get; set; }
        public string WholesalerRoad { get; set; }
        public string WholesalerZipCode { get; set; }
        public string WholesalerPhone { get; set; }
        public string WholesalerEmail { get; set; }
        public IdentityUser OwnerUser { get; set; }
    }
}