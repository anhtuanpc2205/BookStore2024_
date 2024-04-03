using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace BookStore2024.ViewComponents
{
	public class CategoriesMenuViewComponent : ViewComponent
	{
		private readonly BookStoreContext DBContext;
		public CategoriesMenuViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

		public IViewComponentResult Invoke()
		{
			var data = DBContext.TblCategories.Select(Cate => new CategoriesMenuVM
			{
				CategoryId = Cate.CategoryId,
				CategoryName = Cate.CategoryName,
				Quantity = DBContext.ViewBookDetails.Where(bookdetail => bookdetail.CategoryId == Cate.CategoryId).Count()

			}) ; 

			return View("Default",data);
		}
	}
}
