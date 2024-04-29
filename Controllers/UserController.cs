using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.Controllers
{
    public class UserController : Controller
    {
        private readonly BookStoreContext DBContext;
        public UserController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IActionResult Register()
        {

            return View();
        }

    }
}
