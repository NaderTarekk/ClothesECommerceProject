using LaptopShopECommerceProject.Models;

namespace ClothesECommerceProject.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }
        public List<ShoppingCartItem> Items { get; set; }
        public decimal Total { get; set; }
        public string PromoCode { get; set; }
    }
}
