using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly BookStoreContext DBContext;
        public AdminProductsController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        public IActionResult ProductList(string? searchString)
        {
            var ProductsQuery = DBContext.ViewBookDetails.AsQueryable();

            var data = ProductsQuery.Select(p => new ProductVM
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = ("../" + p.BookImageUrl) ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName,
                BookDetailId = p.BookDetailId
            });

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var cateList = DBContext.TblCategories.Select( p => new SelectListItem()
            {
                Text = p.CategoryName,
                Value = p.CategoryId.ToString()
            }).ToList();

            var genreList = DBContext.TblGenres.Select( p => new SelectListItem()
            {
                Text= p.GenreName,
                Value = p.GenreId.ToString()
            }).ToList();

            cateList.Insert(0, new SelectListItem()
            {
                Text = "---select---",
                Value = "0"
            });

            genreList.Insert(0, new SelectListItem
            {
                Text = "---select---",
                Value = "0"
            });

            ViewBag.Categories = cateList;
            ViewBag.Genres = genreList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM formData)
        {
            if(ModelState.IsValid)
            {
                //kiem tra neu chua co thi them moi author
                string checkAuthor = formData.AuthorName ?? "";

                var author = new TblAuthor();
                var existsAuthor = DBContext.TblAuthors.Any(p => p.AuthorName.Trim().ToLower() == checkAuthor.Trim().ToLower());
                if (!existsAuthor)
                {
                    author = new TblAuthor
                    {
                        AuthorName = checkAuthor
                    };
                    DBContext.TblAuthors.Add(author);
                    DBContext.SaveChanges();
                }
                else
                {
                    author = DBContext.TblAuthors.FirstOrDefault(p => p.AuthorName == checkAuthor);
                }
                //add book
                var newBook = new TblBook
                {
                    BookTitle = formData.ProductName ?? "",
                    AuthorId = author.AuthorId,
                    BookImageUrl = formData.ProductImg ?? "",
                    BookDescription = formData.ProductDescription,
                    Publisher = formData.Publisher,
                    Language = formData.Language,
                    IllustrationsNote = formData.IllustrationsNote,
                    Pages = formData.Pages,
                    GenreId = formData.GenreId ?? 0,
                    CategoryId = formData.CategoryId ?? 0
                };
                DBContext.TblBooks.Add(newBook);
                DBContext.SaveChanges();

                var newBookDetail = new TblBookDetail
                {
                    BookId = newBook.BookId,
                    Isbn10 = formData.Isbn10,
                    Isbn13 = formData.Isbn13,
                    FormatId = formData.FormatId ?? 0,
                    StockQuantity = formData.StockQuantity ?? 0,
                    Price = formData.Price ?? 0,
                    Discount = formData.Discount,
                };
                DBContext.TblBookDetails.Add(newBookDetail);
                DBContext.SaveChanges();

                return View("AddSuccessed");
            }
            return View(formData);
        }
        public IActionResult Edit()
        {
            return View();
        }
        
        public IActionResult Search(string? searchString)
        {
            var ProductsQuery = DBContext.ViewBookDetails.AsQueryable();
            
            if (searchString != null && searchString != string.Empty)
            {
                searchString = searchString.Trim().ToLower();
                ProductsQuery = ProductsQuery.Where(p => p.BookTitle.ToLower().Contains(searchString));
            }
            var data = ProductsQuery.Select(p => new ProductVM
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = ("../" + p.BookImageUrl) ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName,
                BookDetailId = p.BookDetailId
            });
            return View("ProductList",data);
        }
    }
}
