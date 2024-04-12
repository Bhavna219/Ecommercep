using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using ShoppingCart.Models.Infrastructure;
using ShoppingCart.Models.ViewModels;

namespace ShoppingCart.Infrastructure.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart= HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SamllCartViewModels smallCartVM;
            if (cart == null || cart.Count==null)
            {
                smallCartVM = null;
            }
            else
            {
                smallCartVM = new()
                {
                   NumberOfItems = cart.Sum(x=> x.Quantity),
                   TotalAmaount=cart.Sum(x => x.Quantity * x.Price),
                };

            }
            return View(smallCartVM);
        }
        
    }
}
