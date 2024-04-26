using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.ViewComponents
{
    public class MegaMenuViewComponent : ViewComponent
    {
        private readonly BookStoreContext DBContext;
        public MegaMenuViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        public IViewComponentResult Invoke()
        {
            var data = DBContext.TblCategories.Select(Cate => new CategoriesMenuVM
            {
                CategoryId = Cate.CategoryId,
                CategoryName = Cate.CategoryName
            });

            return View("Default", data);
        }
    }
}
