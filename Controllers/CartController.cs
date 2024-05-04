using BookStore2024.Data;
using BookStore2024.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BookStore2024.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace BookStore2024.Controllers
{
    public class CartController : Controller
    {
        private readonly BookStoreContext DBContext;
        public CartController(BookStoreContext DatabaseContext) => DBContext = DatabaseContext;
        
        public List<CartItemVM> ListProductsInCart => HttpContext.Session.Get<List<CartItemVM>>(Constants.SESSION_KEY) ?? new List<CartItemVM>();

        public IActionResult Index()
        {
            return View(ListProductsInCart);
        }
        [Authorize]
        public IActionResult AddtoCart(int productDetailId, int quantity = 1)
        {
            var CartList = ListProductsInCart;

            var item = CartList.SingleOrDefault(p => p.BookDetailId == productDetailId);
            
            if (item == null) //nếu chưa có sản phẩm có (id == productDetailId) đó ở trong cart
            {
                var product = DBContext.ViewBookDetails.SingleOrDefault(p => p.BookDetailId == productDetailId); //kiểm tra sản phẩm đó có tồn tại hay không
                if (product == null) //kiểm tra id có tồn tại hay không
                {
                    TempData["Message"] = $"Could not find product have id: {productDetailId} or product does not exist";
                    return Redirect("/404");
                }

                item = new CartItemVM { // nếu tồn tại thì tạo mới và thêm vào giỏ hàng
                    BookDetailId = productDetailId,
                    ProductName = product.BookTitle,
                    ProductImg = product.BookImageUrl,
                    FormatName = product.FormatName,
                    Price = product.Price - (product.Discount ?? 0), //gía được truyền vào view là giá sau khi đã chiết khấu (discount rồi)
                    Quantity = (quantity > 0) ? quantity : 1,
                };

                CartList.Add(item);
            }
            else { item.Quantity += (quantity > 0) ? quantity : 1; }//nếu tồn tại sp trong giỏ hàng rồi thì cập nhật lại số lượng
            HttpContext.Session.Set(Constants.SESSION_KEY, CartList);

            return Redirect(Request.Headers["Referer"].ToString());
            //return NoContent();
        }
		public ActionResult RemoveItem(int productDetailId)
        {
            var CartList = ListProductsInCart;

            var item = CartList.SingleOrDefault(p => p.BookDetailId == productDetailId);

            if (item != null) 
            {
                CartList.Remove(item);
                HttpContext.Session.Set(Constants.SESSION_KEY, CartList);
            }
            return NoContent();
        }
        
        public IActionResult increaseQuantity(int productDetailId)
        {
            var CartList = ListProductsInCart;
            var item = CartList.SingleOrDefault(p => p.BookDetailId == productDetailId);
            if (item != null)
            {
                item.Quantity ++;
            }
            HttpContext.Session.Set(Constants.SESSION_KEY, CartList);
            return NoContent();
        }

        public IActionResult decreaseQuantity(int productDetailId)
        {
            var CartList = ListProductsInCart;
            var item = CartList.SingleOrDefault(p => p.BookDetailId == productDetailId);
            if (item != null)
            {
                if(item.Quantity > 1) { item.Quantity--; }
            }
            HttpContext.Session.Set(Constants.SESSION_KEY, CartList);
            return NoContent();
        }

        public IActionResult ClearCart()
        {
			var CartList = new List<CartItemVM>();
			HttpContext.Session.Set(Constants.SESSION_KEY, CartList);

            return Redirect(Request.Headers["Referer"].ToString());
            //return NoContent();
            //return RedirectToAction("Index");
        }
	}
}
