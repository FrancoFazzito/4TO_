using System;
using System.Linq;
using System.Web.Mvc;
using ArtMarket.Entities.Model;
using ArtMarket.UI.Process;

namespace ArtMarket.UI.Web.Controllers
{
	public class CartController : BaseController
	{
        public CartProcess process { get; set; }
        public ProductProcess processproduct { get; set; }
        public CartItemProcess processcartitem { get; set; }

        //public ProductManagement ProductManagement { get; set; }
        //// GET: Cart

        public CartController()
        {
          process = new CartProcess();
          processproduct = new ProductProcess();
          processcartitem = new CartItemProcess();  
        }

        public ActionResult Index(Cart cart = null)
        {

            if (cart == null)
            {
                var user = 1;
                cart = process.Get(user);
                //cart = process.Add(cart);
            }

            return View("Index", cart);
        }

        public ActionResult Add(int id)
        {
            
            var user = 1;
            var cart = process.Get(user);

            if (cart == null)
            {
                cart = process.Add(cart);
            }

            var prod = processproduct.Get(id);

            var item = new CartItem() { 
                CartId = cart.Id, 
                ProductId = prod.Id, 
                Price = prod.Price, 
                Quantity = 1,
                CreatedOn = DateTime.Now,
                ChangedOn = DateTime.Now
            };

            //CheckAuditPattern(item, true);

            processcartitem.Add(item);

            if (!cart.CartItem.Any(x => x.ProductId == item.ProductId))
            {
                item.Product = prod;
                cart.CartItem.Add(item);
            }

            return Index(cart);
        }

        //public ActionResult Increase(int id)
        //{
        //    var item = Management.GetItem(id);
        //    item.Quantity++;
        //    item.Price = item.Product.Price * item.Quantity;
        //    CheckAuditPattern(item, false);

        //    Management.UpdateItem(item);

        //    return Index();
        //}

        //public ActionResult Decrease(int id)
        //{
        //	var item = Management.GetItem(id);

        //	if (item.Quantity > 1)
        //	{
        //		item.Quantity--;
        //		item.Price = item.Product.Price * item.Quantity;
        //		CheckAuditPattern(item, false);

        //		Management.UpdateItem(item);
        //	}

        //	return Index();
        //}

        //public ActionResult Delete(int id)
        //{
        //	var item = Management.GetItem(id);
        //	Management.RemoveItem(item);

        //	return Index();
        //}
    }
}