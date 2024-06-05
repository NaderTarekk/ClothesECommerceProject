using LaptopShopECommerceProject.Models;

namespace ClothesECommerceProject.Models
{
    public class VmData
    {
        public VmData()
        {
            MainBanners = new List<TbMainBanners>();
            SubBanners = new List<TbSubBanners>();
            MiddleBanners = new List<TbMiddleBanner>();
            FooterBanners = new List<TbFooterBanners>();
            NewProducts = new List<TbClothes>();
            NewProducts2 = new List<TbClothes>();
            FeaturedProducts = new List<TbClothes>();
            FeaturedProducts2 = new List<TbClothes>();
            BestSellers = new List<TbClothes>();
            BestSellers2 = new List<TbClothes>();
            OnSell = new List<TbClothes>();
        }
        public List<TbMainBanners> MainBanners { get; set; }
        public List<TbSubBanners> SubBanners { get; set; }
        public List<TbMiddleBanner> MiddleBanners { get; set; }
        public List<TbFooterBanners> FooterBanners { get; set; }
        public List<TbClothes> NewProducts { get; set; }
        public List<TbClothes> NewProducts2 { get; set; }
        public List<TbClothes> FeaturedProducts { get; set; }
        public List<TbClothes> FeaturedProducts2 { get; set; }
        public List<TbClothes> BestSellers { get; set; }
        public List<TbClothes> BestSellers2 { get; set; }
        public List<TbClothes> OnSell { get; set; }

    }
}
