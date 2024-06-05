using ClothesECommerceProject.Interfaces;
using ClothesECommerceProject.Models;
using LaptopShopECommerceProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace LaptopShopECommerceProject.Controllers
{
    public class HomeController : Controller
    {
        VmData vmData = new VmData();
        private readonly ILogger<HomeController> _logger;
        IBanners _banner;
        IClothes _clothes;
        UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, IClothes clothes, IBanners banners, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _banner = banners;
            _clothes = clothes;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            Random rand = new Random();

            vmData.MainBanners = _banner.MainBanners();
            vmData.SubBanners = _banner.SubBanners();
            vmData.MiddleBanners = _banner.MiddleBanners();
            vmData.FooterBanners = _banner.FooterBanners();
            vmData.NewProducts = _clothes.GetAllClothes().OrderBy(lap => rand.Next()).Take(8).ToList();
            vmData.NewProducts2 = _clothes.GetAllClothes().OrderBy(lap => rand.Next()).Take(6).ToList();
            vmData.FeaturedProducts = _clothes.GetAllClothes().OrderBy(lap => rand.Next()).Take(8).ToList();
            vmData.FeaturedProducts2 = _clothes.GetAllClothes().OrderBy(lap => rand.Next()).Take(6).ToList();
            vmData.BestSellers = _clothes.GetAllClothes().OrderBy(lap => rand.Next()).Take(8).ToList();
            vmData.BestSellers2 = _clothes.GetAllClothes().OrderBy(lap => rand.Next()).Take(6).ToList();
            vmData.OnSell = _clothes.GetAllClothes().OrderBy(lap => rand.Next()).Take(6).ToList();

            if (HttpContext.Request.Cookies["Cart"] != null)
            {
                var cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
                ViewData["NumberOfCartItems"] = cart.Items.Count;
            }

            // check if logged in
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                ViewData["FirstName"] = user.FirstName;
            }
            return View(vmData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
