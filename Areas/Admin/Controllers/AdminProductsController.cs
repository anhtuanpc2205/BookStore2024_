using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly BookStoreContext DBContext;
        public AdminProductsController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        public IActionResult ProductList(string? searchString)
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
        
        public IActionResult Search(string? searchString)
        {
            var ProductsQuery = DBContext.ViewBookDetails.AsQueryable();
            
            if (searchString != null && searchString != string.Empty)
            {
                searchString = searchString.Trim().ToLower();
                ProductsQuery = ProductsQuery.Where(p => p.BookTitle.ToLower().Contains(searchString));
            }
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
            return View("ProductList",data);
        }
    }
}
