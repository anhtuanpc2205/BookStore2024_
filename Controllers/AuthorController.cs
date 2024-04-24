using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.Controllers
{
    public class AuthorController : Controller
    {
		private readonly BookStoreContext DBContext;
		public AuthorController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
		public IActionResult Index()
        {
            var AuthorQuery = DBContext.ViewAuthorDetails.AsQueryable();

            var Data = AuthorQuery.Select(p => new AuthorVM
            {
				AuthorId = p.AuthorId,
                AuthorName = p.AuthorName,
                ProfileImageUrl = p.ProfileImageUrl,
                AuthorDescription = p.AuthorDescription,
                PublishedBook = p.PublishedBook
			});

            return View(Data);
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
				PublishedBook = AuthorQuery.PublishedBook
			};

			return View(data);
		}
	}
}
