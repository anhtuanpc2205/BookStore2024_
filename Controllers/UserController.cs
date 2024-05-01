using AutoMapper;
using BookStore2024.Data;
using BookStore2024.Helpers;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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
            return View();
        }
        #endregion
    }
}
