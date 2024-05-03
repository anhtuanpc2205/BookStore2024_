using AutoMapper;
using BookStore2024.Data;
using BookStore2024.Helpers;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Security.Claims;

namespace BookStore2024.Controllers
{
    public class UserController : Controller
    {
        private readonly BookStoreContext DBContext;
        private readonly IMapper _mapper;
        public UserController(BookStoreContext DatabaseContext, IMapper mapper) {
            DBContext = DatabaseContext;
            _mapper = mapper;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM regisData, IFormFile? ProfileImageUrl)
        {
            if (ModelState.IsValid)
            {
                var record = DBContext.TblUsers.Where(p => p.Email == regisData.Email).SingleOrDefault();
                if (record != null)
                {
                    TempData["Message"] = $"Email has already been registered previously";
                    return View();
                }
                try
                {
                    var User = _mapper.Map<TblUser>(regisData);

                    if (ProfileImageUrl != null)
                    {
                        User.ProfileImageUrl = ProjectUtil.UploadImage(ProfileImageUrl, "users");
                    }
                    else { User.ProfileImageUrl = string.Empty; }

                    DBContext.Add(User);
                    DBContext.SaveChanges();

                    //string g = User.ProfileImageUrl;
                    //string z = regisData.Password;
                    //string x = regisData.ShippingAddress;
                    //string y = regisData.UserName;

                    //TempData["Message"] = $"Register Success!";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = $"some information are provided incorrectly";
                }
            }
            return View();
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            //return ViewComponent("UserLogin");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginInfo)
        {
            if(ModelState.IsValid)
            {
                var user = DBContext.TblUsers.SingleOrDefault( u => u.Email == loginInfo.Email);
                if (user == null)
                {
                    //ModelState.AddModelError("Error", "Invalid user");
                    
                    TempData["Message"] = "Invalid user!";
                    return RedirectToAction("Login");
                }
                else
                {
                    if(user.Password != loginInfo.Password)
                    {
                        TempData["Message"] = "Incorect password!";
                        ViewBag.Msg = Convert.ToString(TempData["Message"]);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim("Email",user.Email),
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim("UserID",user.UserId.ToString()),
                            new Claim("ProfileImageUrl",user.ProfileImageUrl ?? ""),
                            new Claim("Address",user.ShippingAddress),

                            new Claim(ClaimTypes.Role,"Customer")
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        //TempData["Message"] = "login success!";
                        await HttpContext.SignInAsync(claimsPrincipal);

                        ViewBag.UserImg = user.ProfileImageUrl ?? "../user/img-01.jpg";
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            await Response.WriteAsync("<script>alert ('Invalid user or Incorect Password')</script>");
            return RedirectToAction("Login");
        }
        #endregion
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
