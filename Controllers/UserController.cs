using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore2024.Controllers
{
    public class UserController : Controller
    {
        private readonly BookStoreContext DBContext;
        public UserController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IActionResult Registering()
        {
            return View();
        }
    }
}
