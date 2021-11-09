using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class FileuploadController : Controller
    {
        // GET: Fileupload
        public ActionResult Index()
        {
            FileUploadDetails model = new FileUploadDetails();
            DAL sql = new DAL();
            model.MappedList = sql.GetTableData("SP_Fileupload");
            model.SupplierList = model.getallSupplier();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(FileUploadDetails model)
        {
            DAL sql = new DAL();
            DataTable Dt = new DataTable();
            Dt = sql.GetTableData("SP_Fileupload @Opt=3");
            model.DocNo = Dt.Rows[0][0].ToString();

            string[] param = new string[7] { "@Opt", "@DocNo", "@Name", "@Rate", "@supplier", "@Comments", "@Entrydate" };
            object[] value = new object[7] { "2", model.DocNo, model.FileName,model.Rate,model.SupID, model.Comments, model.EntryDate };

            sql.ExecuteNonQuery("SP_Fileupload", param, value);

            foreach (HttpPostedFileBase File in model.Files)
            {
                if (File != null)
                {
                    string _FileName = Path.GetFileName(File.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    File.SaveAs(_path);

                    if (model.FileName != "")
                    {
                        string[] param1 = new string[4] { "@Opt", "@DocNo", "@FileName", "@Fileurl" };
                        object[] value1 = new object[4] { "1", model.DocNo, _FileName, _path };

                        bool reslt = sql.ExecuteNonQuery("SP_Fileupload", param1, value1);

                    }
                }
            }
            ViewBag.Message = "File Uploaded Successfully!!";


            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult Viewpdf(int ID)
        {
            FileUploadDetails model = new FileUploadDetails();
            DAL sql = new DAL();
            DataTable dt = new DataTable();
            dt = sql.GetTableData("SP_Fileupload @Opt=4,@ID=" + ID + "");
            string embed = "<object data=\"{0}\" type=\"application/pdf\"width =\"500px\" height=\"300px\">";
            embed += "</object>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Fileurl"] = string.Format(embed,
                VirtualPathUtility.ToAbsolute("~/UploadedFiles/" + dt.Rows[i]["FileName"]));
            }
            model.documents = dt;
            return PartialView("_Documents", model);
        }
        [HttpGet]
        public ActionResult delete(int ID)
        {
            DAL sql = new DAL();
            DataTable Dt = new DataTable();
            Dt = sql.GetTableData("SP_Fileupload @Opt=4,@ID=" + ID);
            if (Dt != null)
            {
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    string path = Server.MapPath("~/UploadedFiles/" + Dt.Rows[i]["FileName"].ToString());
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete(); 
                    }
                }
            }
            string[] param = new string[2] { "@Opt", "@ID" };
            object[] value = new object[2] { "6", ID };
            bool result = sql.ExecuteNonQuery("SP_Fileupload", param, value);

            FileUploadDetails model = new FileUploadDetails();
            model.MappedList = sql.GetTableData("SP_Fileupload");
            model.SupplierList = model.getallSupplier();
            return PartialView("_List", model);
        }

    }
}