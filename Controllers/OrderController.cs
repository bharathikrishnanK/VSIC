using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            Order model = new Order();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_GetOrders");
            model.OrderList = model.GetallOrder();
            model.OrderStatus = model.GetOrderStatus();

            return View(model);
        }
        public ActionResult refresh(Order model)
        {

            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_GetOrders @Status='" + model.Value + "',@OrdID=" + model.OrdID + ",@startdate='" + Convert.ToString(model.StartDate) + "',@enddate='" + Convert.ToString(model.EndDate) + "'");
            model.OrderList = model.GetallOrder();
            model.OrderStatus = model.GetOrderStatus();

            return View("Index", model);
        }

    }
}