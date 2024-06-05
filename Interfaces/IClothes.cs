using LaptopShopECommerceProject.Models;

namespace ClothesECommerceProject.Interfaces
{
    public interface IClothes
    {
        public List<TbClothes> GetAllClothes();
        public TbClothes GetClothesById(int id);
        public List<TbClothes> RecommendedItems(int id);
    }
}
