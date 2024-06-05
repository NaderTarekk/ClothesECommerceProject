using System.ComponentModel.DataAnnotations;

namespace LaptopShopECommerceProject.Models
{
    public class TbFooterBanners
    {
        [Key]
        public int Id { get; set; }
        public string BannerPath { get; set; }
    }
}
