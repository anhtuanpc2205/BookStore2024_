using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.Controllers
{
	public class AuthorController : Controller
    {
		private readonly BookStoreContext DBContext;
		public AuthorController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
		public async Task<IActionResult> Index(string sortOrder,string currentFilter,string searchString,int pageNumber = 1)
		{
			//if (searchString != null)
			//{
			//	pageNumber = 1;
			//}
			//else
			//{
			//	searchString = currentFilter;
			//}

			var AuthorQuery = DBContext.ViewAuthorDetails.AsQueryable();
			int pageSize = 18;
            var data = AuthorQuery.Select(p => new AuthorVM
            {
				AuthorId = p.AuthorId,
                AuthorName = p.AuthorName,
                ProfileImageUrl = p.ProfileImageUrl,
                AuthorDescription = p.AuthorDescription,
                PublishedBook = p.PublishedBooks ?? 0
			});
			ViewBag.totalAuthor = data.Count();
			return View(await PaginatedList<AuthorVM>.CreateAsync(data, pageNumber, pageSize));
        }

		public IActionResult Detail(int DetailId)
		{
			var AuthorQuery = DBContext.ViewAuthorDetails.Where(p => p.AuthorId == DetailId).SingleOrDefault();
			if (AuthorQuery == null)
			{
				TempData["Message"] = $"Could not find author have id: {DetailId} or product does not exist";
				return Redirect("/404");
			}
			var data = new AuthorVM
			{
				AuthorId = AuthorQuery.AuthorId,
				AuthorName = AuthorQuery.AuthorName,
				ProfileImageUrl = AuthorQuery.ProfileImageUrl,
				AuthorDescription = AuthorQuery.AuthorDescription,
				PublishedBook = AuthorQuery.PublishedBooks ?? 0
			};

			return View(data);
		}
	}
}
