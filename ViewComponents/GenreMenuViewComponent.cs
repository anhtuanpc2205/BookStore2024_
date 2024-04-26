using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.ViewComponents
{
	public class GenreMenuViewComponent : ViewComponent
	{
		private readonly BookStoreContext DBContext;
		public GenreMenuViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

		public IViewComponentResult Invoke(int cateID)
		{
			var data = DBContext.ViewBookDetails.Where(p => p.CategoryId == cateID).Select(p => new ProductVM
			{
				BookDetailId = p.BookDetailId,
				ProductName = p.BookTitle
			});

			//List<string> genre = DBContext.ViewBookDetails.Where(p => p.CategoryId == cateID).Select(p => p.GenreName);

			return View(data);
		}
	}
}
