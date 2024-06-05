using LaptopShopECommerceProject.Models;

namespace ClothesECommerceProject.Interfaces
{
    public interface IBanners
    {
        public List<TbMainBanners> MainBanners();
        public List<TbSubBanners> SubBanners();
        public List<TbMiddleBanner> MiddleBanners();
        public List<TbFooterBanners> FooterBanners();
    }
}
