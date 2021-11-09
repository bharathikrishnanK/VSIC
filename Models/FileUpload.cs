using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace webapp.Models
{
    //public class FileUpload
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public List<FileUploadDetails> Details { get; set; }

    //    public DataTable MappedList { get; set; }
    //}
    public class FileUploadDetails
    {
        public int ID { get; set; }
        public string DocNo { get; set; }
        public string FileName { get; set; } 
        public decimal Rate { get; set; }
        public string Comments { get; set; } 
        public DateTime EntryDate { get; set; }

        [RegularExpression(@"^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$", ErrorMessage = "Incorrect file format")]
        public HttpPostedFileBase[] Files { get; set; } 
        public DataTable documents { get; set; }
        public DataTable MappedList { get; set; }

        public int SupID { get; set; }
        public string SupName { get; set; }
        public List<SupplierList> SupplierList { get; set; }

        public List<SupplierList> getallSupplier()
        {
            SupplierList V = new SupplierList();
            DataTable dt = new DataTable();
            DAL sql = new DAL();
            dt = sql.GetTableData("SP_Fileupload @Opt=5");
            List<SupplierList> SupplierList = new List<SupplierList>();
            SupplierList = dt.AsEnumerable()
               .Select(row => new SupplierList
               {
                   SupID = (int)row["ID"],
                   SupName = row["name"].ToString()
               }).ToList();
            return SupplierList;
        }
    }
    public class SupplierList
    {
        public int SupID { get; set; }
        public string SupName { get; set; }
    }
}