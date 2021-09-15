using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ArtMarket.Entities.Model;
using ArtMarket.UI.Process;

namespace ArtMarket.UI.Web.Controllers
{
    public class DashboardController : Controller
    {
        private ProductProcess _pp;
        private OrderProcess _op;

        public DashboardController()
        {
            _pp = new ProductProcess();
            _op = new OrderProcess();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            var orders = _op.GetAll();
            var totalIncome = orders.Sum(o => o.TotalPrice);
            var currentMonthIncome = orders.Where(x => x.OrderDate.Month == DateTime.Now.Month).Sum(o => o.TotalPrice);

            var vm = new IndexViewModel {TotalIncome = totalIncome, CurrentMonthIncome = currentMonthIncome, PendingClaims = 6, TasksProgress = 72};

            return View(vm);
        }

        public ActionResult Charts()
        {
            var orders = _op.GetAll();

            // Esta query devuelve los montos acumulados por mes pero se pierde el dato de a qué mes corresponde cada monto.
            // var income = orders.GroupBy(o => o.OrderDate.Month).Select(x => x.Sum(o => o.TotalPrice)).ToList();

            // Array de (month -> income)
            var income = orders.
                GroupBy(o => o.OrderDate.Month).
                Select(g => new
                {
                    Month = g.Key,
                    Income = g.Sum(o => o.TotalPrice)
                }).ToList();


            for (int i = 7; i <= 12; i++)
            {
                if (!income.Select(x => x.Month).Contains(i))
                {
                    income.Add(new {Month = i, Income = 0.0});
                }
            }


            ViewBag.Income = income.OrderBy(item => item.Month).Select(item => item.Income).ToList();

            return View();
        }

        public ActionResult Tables()
        {
            var orders = _op.GetAll();

            // avoid orders without order_detail
            orders = orders.Where(o => o.OrderDetail.Count > 0).ToList();

            return View(orders.OrderByDescending(o => o.OrderDate).ToList());
        }
    }

    public class IndexViewModel
    {
        public double TotalIncome { get; set; }
        public double CurrentMonthIncome { get; set; }
        public int TasksProgress { get; set; }
        public int PendingClaims { get; set; }
    }
}