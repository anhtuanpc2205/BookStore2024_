using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore2024.ViewComponents
{
    public class TopBlogersViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public TopBlogersViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IViewComponentResult Invoke()
        {
            var data = DBContext.ViewTopBloger.OrderByDescending(Tb => Tb.NumbersOfPost).Take(4).Select(Tb => new TopBlogersVM
            {
                AuthorId = Tb.AuthorId,
                AuthorName = Tb.AuthorName,
                NumbersOfPost = Tb.NumbersOfPost,
                AuthorImgURL = Tb.AuthorImgURL
            });

            return View("Default",data);
        }
    }
}
