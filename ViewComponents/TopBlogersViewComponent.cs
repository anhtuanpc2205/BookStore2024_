using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.ViewComponents
{
    public class TopBlogersViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public TopBlogersViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IViewComponentResult Invoke()
        {
            var data = DBContext.ViewTopBlogers.OrderByDescending(Tb => Tb.NumBlogs).Take(4).Select(Tb => new TopBlogersVM
            {
                AuthorId = Tb.AuthorId,
                AuthorName = Tb.AuthorName,
                NumbersOfPost = Tb.NumBlogs ?? 0,
                AuthorImgURL = Tb.ProfileImageUrl ?? ""
            });

            return View("Default",data);
        }
    }
}
