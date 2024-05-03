using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookStore2024.ViewComponents
{
    public class BestSellingBooksViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public BestSellingBooksViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        public IViewComponentResult Invoke()
        {
           
            var data = DBContext.ViewTop20BestSellingBooks.Select(p => new ProductVM
            {
                BookDetailId = p.BookDetailId,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = p.BookImageUrl ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName
            });
            return View(data);
        }
    }
}
