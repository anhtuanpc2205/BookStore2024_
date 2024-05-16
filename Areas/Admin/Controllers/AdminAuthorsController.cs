using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAuthorsController : Controller
    {
        private readonly BookStoreContext DBContext;
        public AdminAuthorsController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        public IActionResult Author(string? searchString)
        {
            var AuthorQuery = DBContext.ViewAuthorDetails.AsQueryable();
            return View();
        }
    }
}
