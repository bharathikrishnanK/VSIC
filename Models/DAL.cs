using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace webapp.Models
{
  
    public class DAL
    {
        public const string REGULAREXPRESSION_NUMERIC = "^([0-9]+)$";
        public const string REGULAREXPRESSION_EMAIL = "^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$";
         string Constr= System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ToString();
        //string Constr = "Data Source=DESKTOP-K3K6OB9;Initial Catalog=GARMENTRK;Persist Security Info=True;User ID=sa;Password=sa@123";
        public DataTable GetTableData(string Query)
        {
            SqlConnection Conn = new SqlConnection(Constr);
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            SqlCommand Cmd = new SqlCommand(Query, Conn);
            SqlDataAdapter Apt = new SqlDataAdapter(Cmd);
            DataTable Table = new DataTable();
            Apt.Fill(Table);
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close(); Conn.Dispose();
            }
            return Table;
        }
        public bool ExecuteNonQuery(string ProcedureName, string[] Fields, object[] Values)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(Constr);
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = ProcedureName;
                for (short i = 0; i < Fields.Length; i++)
                {
                    Cmd.Parameters.AddWithValue(Fields[i], Values[i]);
                }
                Cmd.CommandTimeout = 0;
                Cmd.ExecuteNonQuery();
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close(); Conn.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SelectListItem> getYNOptions()
        {
            List<SelectListItem> yn = new List<SelectListItem>();
            yn.Add(new SelectListItem()
            {
                Text = "Yes",
                Value = "Y".ToString(), // error
                Selected = true
            });
            yn.Add(new SelectListItem()
            {
                Text = "No",
                Value = "N".ToString(), // error
                Selected = false
            });
            return yn;
        }
       
    }
}
 