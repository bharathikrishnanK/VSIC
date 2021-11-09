using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class IssueController : Controller
    {
        // GET: Issue
        public ActionResult Index()
        {
            Order ord = new Order();
            Issue model = new Issue();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_Issuedetail");
            model.OrderList = ord.GetallOrder(); 
            model.OrderStatus = ord.GetOrderStatus();
            return View(model);
        }
        public ActionResult refresh(Issue model)
        {
            Order ord = new Order();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_Issuedetail @Status='" + model.Value + "',@OrdID=" + model.OrdID + ",@startdate='" + model.StartDate + "',@enddate='" + model.EndDate + "'");
            model.OrderList = ord.GetallOrder();

            model.OrderStatus = ord.GetOrderStatus();
            return View("Index", model);
        }
    }
}