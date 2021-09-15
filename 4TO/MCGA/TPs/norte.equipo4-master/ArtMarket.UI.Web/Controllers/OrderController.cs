using System;
using System.Linq;
using System.Web.Mvc;
using ArtMarket.Entities.Model;
using ArtMarket.UI.Process;

namespace ArtMarket.UI.Web.Controllers
{
	public class OrderController : BaseController
	{
        //public ICartManagement Management { get; set; }
        //public IOrderManagement OrderManagement { get; set; }
        //public IUserManagement UserManagement { get; set; }

        //public IProductManagement ProductManagement { get; set; }

        public CartProcess cartprocess { get; set; }

        public OrderProcess process { get; set; }
        public ProductProcess productprocess { get; set; }

        public OrderController()
        {
            process = new OrderProcess();
            cartprocess = new CartProcess();
            productprocess = new ProductProcess();

        }

        // GET: Order
        public ActionResult Index()
        {
            return View(process.GetAll());
        }

        //public ActionResult Details(int id)
        //{
        //	return View(OrderManagement.GetItem(id).OrderItems.ToList());
        //}

        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(FormCollection form)
        {
            //var useremail = TryGetUserId();
            var cart = cartprocess.Get(1);
            //var user = UserManagement.Get(useremail);

            Order order = new Order();
            OrderNumber Onumber = new OrderNumber();

            var ListOnumbers = process.GetAll();

            var od = ListOnumbers.OrderByDescending(p => p.Id)
                                 .FirstOrDefault();

            if (od == null)
            {
                Onumber.Number = 0001;
            }
            else
            {
                Onumber.Number = 000 + (od.Id + 1);
            }

            order.OrderDate = DateTime.Now;
            order.ItemCount = cart.CartItem.Count();
            order.TotalPrice = Convert.ToDouble(cart.CartItem.Sum(item => item.Price));
            order.UserId = 1;

            //CheckAuditPattern(order.OrderItems, true);

            order.OrderDetail = cart.CartItem.Select(x => new OrderDetail()
            {
                ProductId = x.ProductId,
                Price = x.Price,
                Quantity = x.Quantity,
                CreatedOn = DateTime.Now,
                ChangedOn = DateTime.Now
            }).ToList();


            try
            {
                //cartprocess.Delete(cart.Id);//LIMPIA EL CARRITO
                //OrderManagement.AddOrderNumber(Onumber);
                order.OrderNumber = Onumber.Id;
                order.ChangedOn = DateTime.Now;
                order.CreatedOn = DateTime.Now;
                process.Add(order); //AGREGA LA ORDEN

                foreach (var item in order.OrderDetail)
                {
                    var prod = productprocess.Get(item.ProductId);
                    prod.QuantitySold += item.Quantity;
                    productprocess.Edit(prod);
                }

            }
            catch (Exception e)
            {
                ExceptionContext ex = new ExceptionContext();
                ex.Exception = e.InnerException;
                OnException(ex);
            }

            return View(order);
        }
    }
}