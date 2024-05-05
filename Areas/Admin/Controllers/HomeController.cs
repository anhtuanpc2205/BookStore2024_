using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;
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

            return View();
        }
        public IActionResult ProductList() { 
            var products_ = db.TblBooks.ToList();
            return View(products_); 
        }
    }
}
