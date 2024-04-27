using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.ViewComponents
{
	public class ProductsInMegaMenuViewComponent : ViewComponent
	{
		private readonly BookStoreContext DBContext;
		public ProductsInMegaMenuViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
		public IViewComponentResult Invoke(int GenreID, int CateID)
		{
			var data = DBContext.ViewBookDetails.Where(p => (p.CategoryId == CateID && p.GenreId == GenreID)).Select(product => new ProductVM
			{
				BookDetailId = product.BookDetailId,
				ProductName = product.BookTitle,
				FormatName = product.FormatName
			}).ToList().OrderByDescending(p => p.Views).Take(3);

			return View(data);
		}
	}
}
