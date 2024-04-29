using BookStore2024.Data;
using BookStore2024.Helpers;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore2024.ViewComponents
{
	public class MinicartViewComponent: ViewComponent
	{
		private readonly BookStoreContext DBContext;
		public MinicartViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

		public List<CartItemVM> ListProductsInCart => HttpContext.Session.Get<List<CartItemVM>>(Constants.SESSION_KEY) ?? new List<CartItemVM>();
		public IViewComponentResult Invoke()
		{
			return View("Default", ListProductsInCart);
		}

	}
}
