using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BookStore2024.Helpers;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace BookStore2024.Controllers
{
    public class CartController : Controller
    {
        private readonly BookStoreContext DBContext;
        public CartController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        
        public List<CartItem> ListProductsInCart => HttpContext.Session.Get<List<CartItem>>(Constants.SESSION_KEY) ?? new List<CartItem>();

        public IActionResult Index()
        {
            return View(ListProductsInCart);
        }
        public IActionResult AddtoCart(int productDetailId)
        {
            var Cart = ListProductsInCart;

            var item = Cart.SingleOrDefault(p => p.BookDetailId == productDetailId);
            
            if (item == null) //nếu chưa có sản phẩm có (id == productDetailId) đó ở trong cart
            {
                var product = DBContext.ViewBookDetails.SingleOrDefault(p => p.BookDetailId == productDetailId); //kiểm tra sản phẩm đó có tồn tại hay không
                if (product == null)
                {
                    TempData["Message"] = $"Could not find product have id: {productDetailId} or product does not exist";
                    return Redirect("/404");
                }
                item = new CartItem {
                    BookDetailId = productDetailId,
                    ProductName = product.BookTitle,
                    ProductImg = product.BookImageUrl,
                    Price = product.Price,
                };

                Cart.Add(item);
            }
            else { }
            HttpContext.Session.Set(Constants.SESSION_KEY, Cart);

            return RedirectToAction("Index");
        }
    }
}
