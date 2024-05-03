using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.Controllers
{
	public class BlogController : Controller
	{
		private readonly BookStoreContext DBContext;
		public BlogController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
		public IActionResult Index()
		{
			var BlogQuery = DBContext.ViewBlogDetails.AsQueryable();

			var data = BlogQuery.OrderByDescending(p => p.Views).Take(9).Select(p => new BlogVM
			{
				BlogId = p.BlogId,
				BlogTitle = p.BlogTitle,
				BlogDescription = p.BlogDescription,
				Content = p.BlogContent,
				AuthorId = p.AuthorId,
				ImgUrl = p.ImgUrl,
				Views = p.Views,
				AuthorName = p.AuthorName
			});

			return View(data);
		}
		public IActionResult Detail(int DetailID)
		{
			var BlogQuery = DBContext.ViewBlogDetails.AsQueryable().Where(p => p.BlogId == DetailID);

			var data = BlogQuery.Select(p => new BlogVM
			{
				BlogId = p.BlogId,
				BlogTitle = p.BlogTitle,
				BlogDescription = p.BlogDescription,
				Content = p.BlogContent,
				AuthorId = p.AuthorId,
				ImgUrl = p.ImgUrl,
				Views = p.Views,
				AuthorName = p.AuthorName
			}).SingleOrDefault();

			return View(data);
		}
	}
}
