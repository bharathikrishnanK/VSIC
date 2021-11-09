using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class ProductionController : Controller
    {
        // GET: Production
        public ActionResult Index()
        {
            Order ord = new Order();
            Production model = new Production();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_Produtionreport");
            model.OrderList = ord.GetallOrder();
            model.OrderStatus = ord.GetOrderStatus();
            return View(model);
        }
        public ActionResult refresh(Production model)
        {
            Order ord = new Order();
            DAL sql = new DAL();
             model.MappedList = sql.GetTableData("SP_Produtionreport  @Status='" + model.Value + "',@OrdID=" + model.OrdID + ",@startdate='" + model.StartDate + "',@enddate='" + model.EndDate + "'");
            model.OrderList = ord.GetallOrder();
            model.OrderStatus = ord.GetOrderStatus();
            return View("Index", model);
        }
    }
}