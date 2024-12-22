using DA_NH.Models;
using DA_NH.Models.ViewModels;
using DA_NH.Utilities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace DA_NH.Controllers
{
    public class CartController : Controller
    {
        private readonly DemoContext _demoContext;
        public CartController(DemoContext context)
        {
            _demoContext = context;
        }
        public IActionResult Index()
        {
          
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemViewModels cartVM = new()
            {
                CaretItems = cartItems,
                GranTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }



        public async Task<IActionResult> Add(int Id)
        {
            MenuItem product = await _demoContext.MenuItems.FindAsync(Id);
            List<CartItemModel> cart= HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemModel cartItems = cart.Where(c => c.ProductId == Id).FirstOrDefault();

            if (cartItems == null)
            {
                cart.Add(new CartItemModel(product));
            }
            else
            {
                cartItems.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // giảm số lượng sản phẩm 
        public async Task<IActionResult> Decrease(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

             if(cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == Id);
            }

             if(cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart"); // setjson?
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart); // setjson?
            }

            return RedirectToAction("Index");
        }

        // tăng số lượng sản phẩm
        public async Task<IActionResult> Increase(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

            if (cartItem.Quantity >=1)
            {
                ++cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == Id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart"); // setjson?
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart); // setjson?
            }

            return RedirectToAction("Index");
        }

        // Xóa sôs lượng sản phẩm
        public async Task<IActionResult> Remove(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            cart.RemoveAll( p=> p.ProductId == Id);
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart"); // setjson?
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart); // setjson?
            }

            return RedirectToAction("Index");
        }
    }
}
