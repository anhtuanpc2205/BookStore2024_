using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore2024.ViewComponents
{
	public class BooksFromAuthorViewComponent : ViewComponent
	{
		private readonly BookStoreContext DBContext;
		public BooksFromAuthorViewComponent(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
		public IViewComponentResult Invoke(int DetailId)
		{
			var listBookPublished = DBContext.ViewBookDetails.Where(p => p.AuthorId == DetailId).Select(book => new ProductVM
			{
				BookDetailId = book.BookDetailId,
				CategoryId = book.CategoryId,
				CategoryName = book.CategoryName,
				ProductName = book.BookTitle,
				ProductImg = book.BookImageUrl ?? "",
				AuthorName = book.AuthorName,
				Price = book.Price,
				Discount = book.Discount,
				FormatName = book.FormatName
			});
			return View("Default",listBookPublished);
		}
	}
}
