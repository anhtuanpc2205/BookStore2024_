using BookStore2024.Data;
using Microsoft.AspNetCore.Mvc;
using BookStore2024.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore2024.ViewComponents
{
    public class NewReleaseBooksViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public NewReleaseBooksViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IViewComponentResult Invoke()
        {
            var data = DBContext.ViewNewReleaseBooks.Select( NRproduct => new ProductVM
            {
                BookDetailId = NRproduct.BookDetailId,
                ProductName = NRproduct.BookTitle,
                AuthorName = NRproduct.AuthorName,
                ProductImg = NRproduct.BookImageUrl,
                GenreName = NRproduct.GenreName,
                CategoryId = NRproduct.CategoryId,
                CategoryName = NRproduct.CategoryName,
                FormatName = NRproduct.FormatName,
                ProductDescription = NRproduct.BookDescription
            });
            return View("Default", data);
        }
    }
}
