using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
            Order ord = new Order();
            Summary model = new Summary();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_SummaryReport");
            model.OrderList = ord.GetallOrder();
            return View(model);
        }
        public ActionResult refresh(Summary model)
        {
            Order ord = new Order();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_SummaryReport @OrdID=" + model.OrdID + ",@startdate='" + model.StartDate + "',@enddate='" + model.EndDate + "'");
            model.OrderList = ord.GetallOrder();
            return View("Index", model);
        }
    }
}