using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Versioning;

namespace BookStore2024.ViewComponents
{
    public class BookAlertViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public BookAlertViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IViewComponentResult Invoke(int? pg_num = 1)
        {
            var data = DBContext.ViewBookAlert.Select(BA => new BookAlertVM
            {
                BookTitle = BA.BookTitle,
                BookDetailId = BA.BookDetailId,
                HomeBannerImageUrl = BA.HomeBannerImageUrl,
                ProductsBannerImageUrl = BA.ProductsBannerImageUrl,
                AuthorName = BA.AuthorName,
                Price = BA.Price,
                Discount = BA.Discount,
                PageNumber = pg_num
            }).FirstOrDefault();
            return View("Default",data);
        }
    }
}
