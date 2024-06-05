using System.ComponentModel.DataAnnotations;

namespace LaptopShopECommerceProject.Models
{
    public class TbMiddleBanner
    {
        [Key]
        public int Id { get; set; }
        public string BannerPath { get; set; }
        public string? Year { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
    }
}
