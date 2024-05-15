using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            
            var dataX = db.TblCategories.Select(Cate => new CategoriesMenuVM
            {
                CategoryName = Cate.CategoryName,
                Quantity = db.ViewBookDetails.Where(bookdetail => bookdetail.CategoryId == Cate.CategoryId).Count()

            }).ToList();

            var chartData = dataX.Select(data => new
            {
                value = data.Quantity,
                name = data.CategoryName
            }).ToArray();

            // Chuyển đổi dữ liệu thành chuỗi JSON
            string jsonData = JsonConvert.SerializeObject(chartData);

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
            // Truyền dữ liệu JSON vào view
            ViewBag.ChartData = jsonData;
           
            ViewBag.Customer = db.TblUsers.Where(u => u.Role == 2).Count();

            
            return View();
        }
    }
}
