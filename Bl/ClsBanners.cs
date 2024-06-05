using ClothesECommerceProject.Interfaces;
using LaptopShopECommerceProject.Models;

namespace ClothesECommerceProject.Bl
{
    public class ClsBanners : IBanners
    {
        ClothesShopContext ctx = new ClothesShopContext();
        public List<TbFooterBanners> FooterBanners()
        {
            try
            {
                var banners = ctx.TbFooterBanners.ToList();
                return banners;
            }
            catch
            {
                return new List<TbFooterBanners>();
            }
        }

        public List<TbMainBanners> MainBanners()
        {
            try
            {
                var banners = ctx.TbMainBanners.ToList();
                return banners;
            }
            catch
            {
                return new List<TbMainBanners>();
            }
        }

        public List<TbMiddleBanner> MiddleBanners()
        {
            try
            {
                var banners = ctx.TbMiddleBanner.ToList();
                return banners;
            }
            catch
            {
                return new List<TbMiddleBanner>();
            }
        }

        public List<TbSubBanners> SubBanners()
        {
            try
            {
                var banners = ctx.TbSubBanners.ToList();
                return banners;
            }
            catch
            {
                return new List<TbSubBanners>();
            }
        }
    }
}
