using BookStore2024.Data;
using BookStore2024.ViewModels;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2024.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BookStoreContext DBContext;
        public ProductsController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        int pageSize = 8;
        public async Task<IActionResult> Index(int? pageNumber, int? category, int? genre)
        {

            var ProductsQuery = DBContext.ViewBookDetails.AsQueryable();

            if (category.HasValue)
            {
                ProductsQuery = ProductsQuery.Where(p => p.CategoryId == category.Value);
            }
            if (genre.HasValue)
            {
                ProductsQuery = ProductsQuery.Where(p => p.GenreId == genre.Value);
            }

            var data = ProductsQuery.Select(p => new ProductVM
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = p.BookImageUrl ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName,
                BookDetailId = p.BookDetailId
            });
            ViewBag.PageSize = pageSize;
            ViewBag.totalProduct = data.Count();
            ViewBag.category = category;
			ViewBag.genre = genre;

			return View(await PaginatedList<ProductVM>.CreateAsync(data, pageNumber ?? 1, pageSize));
            //return View(data);
        }
        public IActionResult Search(string? searchString)
        {
            var ProductsQuery = DBContext.ViewBookDetails.AsQueryable();
            if (searchString != null)
            {
                ProductsQuery = ProductsQuery.Where(p => p.BookTitle.ToLower().Contains(searchString.ToLower()));
            }
            var data = ProductsQuery.Select(p => new ProductVM
            {
                BookDetailId = p.BookDetailId,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = p.BookImageUrl ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName
            }).ToList();

            return View(data);
        }
        public IActionResult Detail(int DetailId)
        {
            var record = DBContext.ViewBookDetails.Where(p => p.BookDetailId == DetailId).SingleOrDefault();
            if (record == null)
            {
                TempData["Message"] = $"Could not find product have id: {DetailId} or product does not exist";
                return Redirect("/404");
            }
            var data = new ProductVM
            {
                BookDetailId = record.BookDetailId,
                CategoryId = record.CategoryId,
                CategoryName = record.CategoryName,
                ProductName = record.BookTitle,
                ProductImg = record.BookImageUrl ?? "",
                AuthorId = record.AuthorId,
                AuthorName = record.AuthorName,
                ProfileImageUrl = record.ProfileImageUrl,
                Price = record.Price,
                Discount = record.Discount,
                FormatId = record.FormatId,
                FormatName = record.FormatName,
                GenreName = record.GenreName,
                GenreId = record.GenreId,
                Publisher = record.Publisher,
                ProductDescription = record.BookDescription,
                Language = record.Language,
                Pages = record.Pages,
                IllustrationsNote = record.IllustrationsNote,
                Isbn10 = record.Isbn10,
                Isbn13 = record.Isbn13,
                StockQuantity = record.StockQuantity,
                Views = record.Views
            };

            return View(data);
        }

        public async Task<IActionResult> BestSelling(int? pageNumber, int? category, int? genre)
        {
            var Query = DBContext.ViewTop20BestSellingBooks.AsQueryable();

            if (Query == null)
            {
                TempData["Message"] = $"Could not find product or product does not exist";
                return Redirect("/404");
            }

            var data = Query.Select(p => new ProductVM
            {
                BookDetailId = p.BookDetailId,
                CategoryId = p.CategoryId ?? 0,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = p.BookImageUrl ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName
            });
            ViewBag.PageSize = pageSize;
            ViewBag.totalProduct = data.Count();
            ViewBag.category = category;
			ViewBag.genre = genre;
			return View(await PaginatedList<ProductVM>.CreateAsync(data, pageNumber ?? 1, pageSize));
            //return View(data);
        }

        public async Task<IActionResult> WeeklySale(int? pageNumber, int? category, int? genre)
        {
            var Query = DBContext.ViewBookDetails.AsQueryable();

            if (Query == null)
            {
                TempData["Message"] = $"Could not find product or product does not exist";
                return Redirect("/404");
            }
            else
            {
                Query = Query.Where(p => p.Discount != 0);
            }

            var data = Query.Select(p => new ProductVM
            {
                BookDetailId = p.BookDetailId,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = p.BookImageUrl ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName
            });
            ViewBag.PageSize = pageSize;
            ViewBag.totalProduct = data.Count();
            ViewBag.category = category;
			ViewBag.genre = genre;
			return View(await PaginatedList<ProductVM>.CreateAsync(data, pageNumber ?? 1, pageSize));
        }



    }
}
