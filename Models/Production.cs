using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace webapp.Models
{
    public class Production
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public int OrdID { get; set; }
        public string OrderNo { get; set; }
        public List<OrderList> OrderList { get; set; }


        public string Value { get; set; }
        public string OrdStatus { get; set; }

        public List<OrderStatus> OrderStatus { get; set; }
        public DataTable MappedList { get; set; }
        //public List<OrderList> GetallOrder()
        //{
        //    OrderList V = new OrderList();
        //    DataTable dt = new DataTable();
        //    DAL sql = new DAL();
        //    dt = sql.GetTableData("SP_GetorderMaster");
        //    List<OrderList> Orderlist = new List<OrderList>();
        //    Orderlist = dt.AsEnumerable()
        //       .Select(row => new OrderList
        //       {
        //           OrdID = (int)row["OrdID"],
        //           OrderNo = row["OrderNo"].ToString()
        //       }).ToList();
        //    return Orderlist;
        //}
    } 
}