using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore2024.ViewComponents
{
    public class TrendingPostViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public TrendingPostViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IViewComponentResult Invoke()
        {
            var data = DBContext.ViewBlogDetail
                            .OrderByDescending(Blo => Blo.Views)
                            .Take(4)
                            .Select(Blo => new BlogVM
                            {
                                BlogId = Blo.BlogId,
                                BlogTitle = Blo.BlogTitle,
                                BlogDescription = Blo.BlogDescription,
                                Content = Blo.BlogContent,
                                AuthorId = Blo.AuthorId,
                                ImgUrl = Blo.BlogImageUrl,
                                Views = Blo.Views,
                                AuthorName = Blo.AuthorName,
                            });
            return View("Default", data);
        }

    }
}
