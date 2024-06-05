﻿using System.ComponentModel.DataAnnotations;

namespace LaptopShopECommerceProject.Models
{
    public class TbMainBanners
    {
        [Key]
        public int Id { get; set; }
        public string BannerPath { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
    }
}
