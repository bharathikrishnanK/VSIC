﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace webapp.Models
{
    public class Dateproduction
    {
         
        [Display(Name = "From Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Select Start Date!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate
        {

            get;set;
        }

        [Display(Name = "End Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Select End Date!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate
        {get;set;
        }
        public int OrdID { get; set; }
        public string OrderNo { get; set; }
        public List<OrderList> OrderList { get; set; }

        public string Value { get; set; }
        public string OrdStatus { get; set; }
        public List<OrderStatus> OrderStatus { get; set; }
        public DataTable MappedList { get; set; }
    }
}