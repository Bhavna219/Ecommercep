using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.Infrastructure;
using ShoppingCart.Models.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;

namespace ShoppingCart.Controllers
{
    public class CartController1 : Controller
    {

        private readonly DataContext _context;

        public CartController1(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          
            
          List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart")??new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal= cart.Sum(x => x.Quantity * x.Price),
            };
            return View(cartVM);
        }

        public async Task <IActionResult> Add(long Id)
        {
            Product product= await _context.Products.FindAsync(Id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem=cart.Where(c => c.ProductId== Id).FirstOrDefault();

            if(cartItem!=null)
            {
                cart.Add(cartItem(product));
            }
            else
            {
                cart.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart",cart);
            TempData["Success"] = "The Product has been added!";

            return Redirect(Request.Headers["Refer"].ToString);
        }

        private IActionResult Redirect(Func<string> toString)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Decrease (long Id)
        {
            Product product = await _context.Products.FindAsync(Id);

        List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

            if (cartItem.Quantity>1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p=> p.ProductId == Id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {


                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "The Product has been Remove!";

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Remove(long Id)
        {
            Product product = await _context.Products.FindAsync(Id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

         
          
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {


                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "The Product has been Remove!";

            return RedirectToAction("Index");
        }


        public IActionResult Clear()
        {
           
                HttpContext.Session.Remove("Cart");
           
            return RedirectToAction("Index");
        }
    }
}
