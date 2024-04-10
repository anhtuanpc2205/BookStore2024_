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
        public IActionResult AddtoCart(int productDetailId, int quantity = 1)
        {
            var Cart = ListProductsInCart;

            var item = Cart.SingleOrDefault(p => p.BookDetailId == productDetailId);
            
            if (item == null) //nếu chưa có sản phẩm có (id == productDetailId) đó ở trong cart
            {
                var product = DBContext.ViewBookDetails.SingleOrDefault(p => p.BookDetailId == productDetailId); //kiểm tra sản phẩm đó có tồn tại hay không
                if (product == null) //kiểm tra id có tồn tại hay không
                {
                    TempData["Message"] = $"Could not find product have id: {productDetailId} or product does not exist";
                    return Redirect("/404");
                }

                item = new CartItem { // nếu tồn tại thì tạo mới và thêm vào giỏ hàng
                    BookDetailId = productDetailId,
                    ProductName = product.BookTitle,
                    ProductImg = product.BookImageUrl,
                    Price = product.Price - product.Discount, //gía được truyền vào view là giá sau khi đã chiết khấu (discount rồi)
                    Quantity = quantity
                };

                Cart.Add(item);
            }
            else { }//nếu tồn tại sp trong giỏ hàng rồi thì không cần add vào nữa
            HttpContext.Session.Set(Constants.SESSION_KEY, Cart);

            return RedirectToAction("Index");
        }
        public IActionResult RemoveItem(int productDetailId)
        {
            var Cart = ListProductsInCart;

            var item = Cart.SingleOrDefault(p => p.BookDetailId == productDetailId);

            if (item != null) 
            {
                Cart.Remove(item);
                HttpContext.Session.Set(Constants.SESSION_KEY, Cart);
            }
            return RedirectToAction("Index");
        }
        //public IActionResult ChangeQuantity(int productDetailId ,int actionType = 1)
        //{
        //    var Cart = ListProductsInCart;
        //    var item = Cart.SingleOrDefault(p => p.BookDetailId == productDetailId);
        //    if (item != null)
        //    {
        //        switch (actionType)
        //        {
        //            case 1: item.Quantity++; break;
        //            case 2: item.Quantity--; break;
        //            default: break;
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}
		public IActionResult ClearCart()
        {
			var Cart = new List<CartItem>();
			HttpContext.Session.Set(Constants.SESSION_KEY, Cart);
            return RedirectToAction("Index");
			//return Json(new { success = true, message = "Cập nhật giỏ hàng thành công!" });
		}
	}

	
}
