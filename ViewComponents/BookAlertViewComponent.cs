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

        public IViewComponentResult Invoke()
        {
            var data = DBContext.ViewBookAlert.Select(BA => new BookAlertVM
            {
                BookTitle = BA.BookTitle,
                BookDetailId = BA.BookDetailId,
                BookImageUrl = BA.BookImageUrl,
                AuthorName = BA.AuthorName,
                Price = BA.Price,
                Discount = BA.Discount
            }).FirstOrDefault();
            return View("Default",data);
        }
    }
}
