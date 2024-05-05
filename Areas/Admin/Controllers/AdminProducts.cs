using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProducts : Controller
    {
        private readonly BookStoreContext DBContext;
        public AdminProducts(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        public IActionResult ProductList()
        {
            var ProductsQuery = DBContext.ViewBookDetails.AsQueryable();

            var data = ProductsQuery.Select(p => new ProductVM
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = ("../" + p.BookImageUrl) ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName,
                BookDetailId = p.BookDetailId
            });

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
