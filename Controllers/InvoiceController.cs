using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            Order ord = new Order();
            Invoice model = new Invoice();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_Invoicereport");
            model.OrderList = ord.GetallOrder();
            model.OrderStatus = ord.GetOrderStatus();
            return View(model);
        }
        public ActionResult refresh(Invoice model)
        {
            Order ord = new Order();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_Invoicereport @Status='" + model.Value + "',@OrdID=" + model.OrdID + ",@startdate='" + model.StartDate + "',@enddate='" + model.EndDate + "'");
            model.OrderList = ord.GetallOrder();

            model.OrderStatus = ord.GetOrderStatus();
            return View("Index", model);
        }
    }
}