using ClothesECommerceProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ClothesECommerceProject.Controllers
{
    public class UserController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
            UserLoginModel model = new UserLoginModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public IActionResult Register(string returnUrl)
        {
            UserModel model = new UserModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            //user.ReturnUrl = "~/";
            if (!ModelState.IsValid)
                return View("Register", user);

            ApplicationUser appUser = new ApplicationUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(appUser, user.Password, true, true);
                    var myUser = await  _userManager.FindByEmailAsync(appUser.Email);
                    await _userManager.AddToRoleAsync(myUser, "Customer");
                    if (loginResult.Succeeded)
                    {
                        if (string.IsNullOrEmpty(user.ReturnUrl))
                            return Redirect("~/");
                        else
                            return Redirect(user.ReturnUrl);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            return View(new UserModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            ApplicationUser appUser = new ApplicationUser()
            {
                Email = user.Email,
                UserName = user.Email
            };

            try
            {
                var loginResult = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, true);
                if (loginResult.Succeeded)
                {
                    if (string.IsNullOrEmpty(user.ReturnUrl))
                        return Redirect("~/");
                    else
                        return Redirect(user.ReturnUrl);
                }
                else
                    return View(user);

            }
            catch (Exception ex)
            {

            }
            return View(new UserModel());
        }


        //var user2 = await _userManager.FindByEmailAsync(user.Email);
        //if (user2 == null)
        //{
        //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    return View(user);
        //}


        public IActionResult AccessDenide()
        {
            return View();
        }
    }
}
