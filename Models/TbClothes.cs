using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LaptopShopECommerceProject.Models
{
    public class TbClothes
    {
        [Key]
        [ValidateNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int StarRating { get; set; }
        public string Color { get; set;}
        public bool isAvailable { get; set;}
        public int Category { get; set; }
        public TbCategories CategoryId { get; set; }
    }
}
