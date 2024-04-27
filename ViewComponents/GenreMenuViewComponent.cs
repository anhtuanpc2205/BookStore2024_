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
			var data = DBContext.ViewBookDetails.Where(p => p.CategoryId == cateID).Select(p => new GenreVM
			{
				GenreId = p.GenreId,
				GenreName = p.GenreName
			}).Distinct().ToList();

			ViewBag.cateID = cateID;

			return View(data);
		}
	}
}
