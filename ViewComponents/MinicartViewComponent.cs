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

		public List<CartItem> ListProductsInCart => HttpContext.Session.Get<List<CartItem>>(Constants.SESSION_KEY) ?? new List<CartItem>();
		public IViewComponentResult Invoke()
		{
			return View("Default", ListProductsInCart);
		}

	}
}
