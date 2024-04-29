using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.Controllers
{
    public class UserController : Controller
    {
        private readonly BookStoreContext DBContext;
        public UserController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM regisData)
        {
            if(ModelState.IsValid)
            {
                var User = regisData;
            }
            return View();
        }

    }
}
