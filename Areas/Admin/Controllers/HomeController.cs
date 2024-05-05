using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookStore2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly BookStoreContext db;
        public HomeController(BookStoreContext DatabaseContext) => db = DatabaseContext;
        public IActionResult Index()
        {
            var chartData = new[]
            {
                new { value = 1048, name = "Search Engine" },
                new { value = 735, name = "Direct" },
                new { value = 580, name = "Email" },
                new { value = 484, name = "Union Ads" },
                new { value = 700, name = "Video Ads" }
            };

            // Chuyển đổi dữ liệu thành chuỗi JSON
            string jsonData = JsonConvert.SerializeObject(chartData);

            // Truyền dữ liệu JSON vào view
            ViewBag.ChartData = jsonData;

            var Query = db.ViewTop20BestSellingBooks.AsQueryable();
            if (Query == null)
            {
                TempData["Message"] = $"Could not find product or product does not exist";
                return Redirect("/404");
            }
            var topSelling = Query.Select(p => new ProductVM
            {
                BookDetailId = p.BookDetailId,
                CategoryId = p.CategoryId ?? 0,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = p.BookImageUrl ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName
            }).Take(10).ToList();
            
            ViewBag.TopSelling = topSelling;

            return View();
        }
    }
}
