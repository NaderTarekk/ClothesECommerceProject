using LaptopShopECommerceProject.Models;

namespace ClothesECommerceProject.Models
{
    public class VmItemDetails
    {
        public TbClothes Item { get; set; }
        public List<TbClothes> RelatedItems { get; set; }
    }
}
