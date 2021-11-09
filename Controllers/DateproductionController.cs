using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class DateproductionController : Controller
    {
        // GET: Dateproduction
        public ActionResult Index(Dateproduction model)
        {
            Order ord = new Order();
            DAL sql = new DAL();

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1); 

            model.StartDate = startDate;

            model.EndDate = endDate;

            model.MappedList = sql.GetTableData("SP_Produtiondetail @Status='" + model.Value + "',@OrdID=" + model.OrdID + ",@startdate1='" + model.StartDate + "',@enddate1='" + model.EndDate + "'");
            model.OrderList = ord.GetallOrder();
            model.OrderStatus = ord.GetOrderStatus();
            return View(model);

        }
        public ActionResult refresh(Dateproduction model)
        {
            Order ord = new Order();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_Produtiondetail @Status='" + model.Value + "',@OrdID=" + model.OrdID + ",@startdate1='" + model.StartDate + "',@enddate1='" + model.EndDate + "'");
            model.OrderList = ord.GetallOrder();
            model.OrderStatus = ord.GetOrderStatus();
            return View("Index", model);
        }
    }
}