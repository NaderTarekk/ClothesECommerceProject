using ClothesECommerceProject.Interfaces;
using ClothesECommerceProject.Models;
using LaptopShopECommerceProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClothesECommerceProject.Controllers
{
    public class ClothesController : Controller
    {
        IClothes _clothes;
        public ClothesController(IClothes clothes)
        {
           
            _clothes = clothes;
        }
        public IActionResult ItemDetails(int id)
        {
            VmItemDetails vmItemDetails = new VmItemDetails();
            vmItemDetails.Item = _clothes.GetClothesById(id);
            vmItemDetails.RelatedItems = _clothes.RecommendedItems(id);
            if (HttpContext.Request.Cookies["Cart"] != null)
            {
                var cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
                // HttpContext.Session.GetString("Cart") 
                ViewData["NumberOfCartItems"] = cart.Items.Count;
            }
            return View(vmItemDetails);
        }
    }
}
