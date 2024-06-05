using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LaptopShopECommerceProject.Models
{
    public class TbCategories
    {
        [Key]
        [ValidateNever]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<TbClothes> Clothes { get; set; }
    }
}
