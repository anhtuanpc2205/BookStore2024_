using BookStore2024.Data;
using BookStore2024.Helpers;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Drawing.Printing;
using System.Net;

namespace BookStore2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly BookStoreContext DBContext;
        public AdminProductsController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;

        #region Display
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

        public IActionResult Sale(string? searchString)
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
                ProductImg = ("../" + p.BookImageUrl) ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName
            }).ToList();

            return View(data);
        }

        public IActionResult BestSelling(int? pageNumber, int? category, int? genre)
        {
            var Query = DBContext.ViewTop20BestSellingBooks.AsQueryable();

            if (Query == null)
            {
                TempData["Message"] = $"Could not find product or product does not exist";
                return Redirect("/404");
            }

            var data = Query.OrderByDescending(p => p.TotalQuantitySold).Take(20).Select(p => new ProductVM
            {
                BookDetailId = p.BookDetailId,
                CategoryId = p.CategoryId ?? 0,
                CategoryName = p.CategoryName,
                ProductName = p.BookTitle,
                ProductImg = ("../" + p.BookImageUrl) ?? "",
                AuthorName = p.AuthorName,
                Price = p.Price,
                Discount = p.Discount,
                FormatName = p.FormatName,
                Sold = p.TotalQuantitySold
            }).ToList();

            return View(data);
        }

        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            var cateList = DBContext.TblCategories.Select(p => new SelectListItem()
            {
                Text = p.CategoryName,
                Value = p.CategoryId.ToString()
            }).ToList();

            var genreList = DBContext.TblGenres.Select(p => new SelectListItem()
            {
                Text = p.GenreName,
                Value = p.GenreId.ToString()
            }).ToList();

            var formatList = DBContext.TblFormats.Select(p => new SelectListItem()
            {
                Text = p.FormatName,
                Value = p.FormatId.ToString()
            }).ToList();

            cateList.Insert(0, new SelectListItem()
            {
                Text = "---select---",
                Value = "0"
            });

            genreList.Insert(0, new SelectListItem()
            {
                Text = "---select---",
                Value = "0"
            });

            formatList.Insert(0, new SelectListItem() 
            {
                Text = "---select---",
                Value = "0"
            });

            ViewBag.Categories = cateList;
            ViewBag.Genres = genreList;
            ViewBag.Formats = formatList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM formData, IFormFile? ProductImg)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    //kiem tra neu chua co thi them moi author
                    string checkAuthor = formData.AuthorName ?? "";

                    var author = new TblAuthor();
                    author = DBContext.TblAuthors.Where(p => p.AuthorName.Trim().ToLower() == checkAuthor.Trim().ToLower()).FirstOrDefault();

                    //var existsAuthor = DBContext.TblAuthors.Any(p => p.AuthorName.Trim().ToLower() == checkAuthor.Trim().ToLower());
                    if (author == null)
                    {
                        author = new TblAuthor
                        {
                            AuthorName = checkAuthor
                        };
                        DBContext.TblAuthors.Add(author);
                        DBContext.SaveChanges();
                    }
                    
                    author = DBContext.TblAuthors.FirstOrDefault(p => p.AuthorId == author.AuthorId);
                    
                    //add book

                    var newBook = new TblBook
                    {
                        BookTitle = formData.ProductName ?? "",
                        AuthorId = author.AuthorId,
                        BookDescription = formData.ProductDescription,
                        Publisher = formData.Publisher,
                        Language = formData.Language,
                        IllustrationsNote = formData.IllustrationsNote,
                        Pages = formData.Pages,
                        GenreId = formData.GenreId,
                        CategoryId = formData.CategoryId
                    };

                    if (ProductImg != null)
                    {
                        newBook.BookImageUrl = ProjectUtil.UploadImage(ProductImg, "books");
                    }
                    else { newBook.BookImageUrl = ""; }
                    DBContext.TblBooks.Add(newBook);
                    DBContext.SaveChanges();

                    var newBookDetail = new TblBookDetail
                    {
                        BookId = newBook.BookId,
                        Isbn10 = formData.Isbn10,
                        Isbn13 = formData.Isbn13,
                        FormatId = formData.FormatId,
                        StockQuantity = formData.StockQuantity ?? 0,
                        Price = formData.Price ?? 0,
                        Discount = formData.Discount,
                    };
                    DBContext.TblBookDetails.Add(newBookDetail);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    TempData["return"] = "Add - Input Eror";
                    return View("Successed");
                }
                TempData["return"] = "Add Successed: " + formData.ProductName;
                return View("Successed");
            }
            TempData["return"] = "Add - Database Eror";
            return View("Successed");
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int detailID)
        {
            var cateList = DBContext.TblCategories.Select(p => new SelectListItem()
            {
                Text = p.CategoryName,
                Value = p.CategoryId.ToString()
            }).ToList();

            var genreList = DBContext.TblGenres.Select(p => new SelectListItem()
            {
                Text = p.GenreName,
                Value = p.GenreId.ToString()
            }).ToList();

            var formatList = DBContext.TblFormats.Select(p => new SelectListItem()
            {
                Text = p.FormatName,
                Value = p.FormatId.ToString()
            }).ToList();

            var productQuery = DBContext.ViewBookDetails.Where(p => p.BookDetailId == detailID).SingleOrDefault();

            ProductVM product = new ProductVM()
            {
                BookDetailId = detailID,
                ProductName = productQuery.BookTitle,
                ProductDescription = productQuery.BookDescription,
                GenreId = productQuery.GenreId,
                GenreName = productQuery.GenreName,
                CategoryId = productQuery.CategoryId,
                CategoryName = productQuery.CategoryName,
                Price = productQuery.Price,
                Discount = productQuery.Discount,
                Publisher = productQuery.Publisher,
                ProductImg = productQuery.BookImageUrl,
                AuthorId = productQuery.AuthorId,
                AuthorName = productQuery.AuthorName,
                Language = productQuery.Language,
                Pages = productQuery.Pages,
                IllustrationsNote = productQuery.IllustrationsNote,
                Isbn10 = productQuery.Isbn10,
                Isbn13 = productQuery.Isbn13,
                FormatId = productQuery.FormatId,
                FormatName = productQuery.FormatName,
                StockQuantity = productQuery.StockQuantity,
                BookId = productQuery.BookId,

            };

            cateList.Insert(0, new SelectListItem()
            {
                Text = product.CategoryName,
                Value = product.CategoryId.ToString()
            });

            genreList.Insert(0, new SelectListItem()
            {
                Text = product.GenreName,
                Value = product.GenreName.ToString()
            });

            formatList.Insert(0, new SelectListItem()
            {
                Text = product.FormatName,
                Value = product.FormatId.ToString()
            });
            ViewBag.Categories = cateList;
            ViewBag.Genres = genreList;
            ViewBag.Formats = formatList;
            ViewBag.Img = "../" + product.ProductImg;
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM formData, IFormFile? ProductImg, int? id)
        {
            if (ModelState.IsValid)
            {
                var product = DBContext.ViewBookDetails.SingleOrDefault(p => p.BookDetailId == id);
                if (product != null)
                {
                    //author
                    string checkAuthor = formData.AuthorName ?? "";

                    var author = new TblAuthor();
                    author = DBContext.TblAuthors.Where(p => p.AuthorName.Trim().ToLower() == checkAuthor.Trim().ToLower()).FirstOrDefault();

                    //var existsAuthor = DBContext.TblAuthors.Any(p => p.AuthorName.Trim().ToLower() == checkAuthor.Trim().ToLower());
                    if (author == null)
                    {
                        author = new TblAuthor
                        {
                            AuthorName = checkAuthor
                        };
                        DBContext.TblAuthors.Add(author);
                        DBContext.SaveChanges();
                    }

                    author = DBContext.TblAuthors.FirstOrDefault(p => p.AuthorId == author.AuthorId);
                    ////////////////////////////////////
                    var book = DBContext.TblBooks.FirstOrDefault(p => p.BookId == product.BookId);

                    if (book is not null)
                    {
                        if(formData.ProductName != null)
                        {
                            book.BookTitle = formData.ProductName;
                        }
                        if(author != null)
                        {
                            book.AuthorId = author.AuthorId;
                        }
                        book.BookDescription = formData.ProductDescription;
                        book.Publisher = formData.Publisher;
                        book.Language = formData.Language;
                        book.IllustrationsNote = formData.IllustrationsNote;
                        book.Pages = formData.Pages;
                        book.GenreId = formData.GenreId;
                        book.CategoryId = formData.CategoryId;
                        if (ProductImg != null)
                        {
                            book.BookImageUrl = ProjectUtil.UploadImage(ProductImg, "books");
                        }

                        DBContext.Update(book);
                        DBContext.SaveChanges();
                    }
                    ////////////////////////////////////
                    var bookdetail = DBContext.TblBookDetails.FirstOrDefault(p => p.BookDetailId == product.BookDetailId);

                    if (bookdetail is not null)
                    {
                        bookdetail.BookId = bookdetail.BookId;
                        bookdetail.Isbn10 = formData.Isbn10;
                        bookdetail.Isbn13 = formData.Isbn13;
                        bookdetail.FormatId = formData.FormatId;
                        bookdetail.StockQuantity = formData.StockQuantity ?? 0;
                        bookdetail.Price = formData.Price ?? 0;
                        bookdetail.Discount = formData.Discount ?? 0;

                        DBContext.Update(bookdetail);
                        DBContext.SaveChanges();
                    }
                    TempData["return"] = "Edited: " + formData.ProductName;
                    return View("Successed");
                }
                
               
            }
            TempData["return"] = "Fail to edited: " + formData.ProductName;
            return View("Successed");
        }
        #endregion

        #region Search
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
            return View("ProductList", data);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int detailID)
        {
            var product = DBContext.TblBookDetails.Where(p => p.BookDetailId == detailID).FirstOrDefault();

            var inNewRelease = DBContext.TblNewReleaseBooks.Where(p => p.BookDetailId == detailID).FirstOrDefault();
            var inBookAlert = DBContext.TblBookAlerts.Where(p => p.BookDetailId == detailID).FirstOrDefault();

            if (inNewRelease != null) {
                DBContext.TblNewReleaseBooks.Remove(inNewRelease);
            }
            if(inBookAlert != null)
            {
                DBContext.TblBookAlerts.Remove(inBookAlert);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion
    }
}
