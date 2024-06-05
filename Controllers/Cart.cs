using ClothesECommerceProject.Interfaces;
using ClothesECommerceProject.Models;
using LaptopShopECommerceProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace ClothesECommerceProject.Controllers
{
    public class Cart : Controller
    {
        IClothes _iclothes;
        public Cart(IClothes clothes)
        {
            _iclothes = clothes;
        }
        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies["Cart"] != null)
            {
                var cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
                // HttpContext.Session.GetString("Cart") 
                ViewData["NumberOfCartItems"] = cart.Items.Count;
                return View(cart);
            }
            return View(new ShoppingCart());
        }
        [Authorize]
        public IActionResult Checkout()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder OrderId = new StringBuilder();
            for (int i = 0; i < 17; i++)
            {
                OrderId.Append(chars[random.Next(chars.Length)]);
            }
            var cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
            ViewData["NumberOfCartItems"] = cart.Items.Count;
            ViewBag.OrderId = OrderId.ToString();
            return View(cart);
        }
        public IActionResult DeleteProduct(int id)
        {

            var cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
            var product = cart.Items.FirstOrDefault(a => a.Id == id);
            // HttpContext.Session.GetString("Cart") 
            cart.Items.Remove(product);
            cart.Total = cart.Items.Sum(a => a.Total);
            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));
            return View("Index", cart);
        }
        public IActionResult AddToCart(int itemId)
        {
            var item = _iclothes.GetClothesById(itemId);

            //using cookies
            // check if cart in session 
            ShoppingCart cart;
            if (HttpContext.Request.Cookies["Cart"] != null)
                cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
            else
                cart = new ShoppingCart();

            // check if item is founded
            var itemInList = cart.Items.FirstOrDefault(a => a.Id == itemId);
            if (itemInList != null)
            {
                itemInList.Qty++;
                itemInList.Total = itemInList.Qty * itemInList.Price;
            }
            else
            {
                cart.Items.Add(new ShoppingCartItem
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    Price = (decimal)item.Price,
                    Qty = 1,
                    Total = (decimal)item.Price
                });
            }

            //caculate all items total
            cart.Total = cart.Items.Sum(a => a.Total);


            //add cart to cookies
            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            // add cart to session
            //HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return Redirect("/Clothes/ItemDetails/" + itemId);
        }
    }
}
