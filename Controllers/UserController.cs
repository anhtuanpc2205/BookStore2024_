using AutoMapper;
using BookStore2024.Data;
using BookStore2024.Helpers;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM regisData, IFormFile? ProfileImageUrl)
        {
            if(ModelState.IsValid)
            {
                try { 
                    var User = _mapper.Map<TblUser>(regisData);

                    if(ProfileImageUrl != null)
                    {
                        User.ProfileImageUrl = ProjectUtil.UploadImage(ProfileImageUrl, "users");
                    }

                    DBContext.Add(User);
                    DBContext.SaveChanges();

                    //string g = User.ProfileImageUrl;
                    //string z = regisData.Password;
                    //string x = regisData.ShippingAddress;
                    //string y = regisData.UserName;

                    return RedirectToAction("Index","Home");
                }catch(Exception ex)
                {

                }
            }
            return View();
        }

    }
}
