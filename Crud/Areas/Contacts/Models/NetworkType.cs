using PMSRedirect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Areas.Contacts.Models
{
    public class NetworkType
    {
        UserSessions session = new UserSessions();
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Contact"].ConnectionString);
        //-------------------------------------------------------------------------------
        public int? ID { get; set; }
        public string Name { get; set; }
        public int? EncBy { get; set; }
        public DateTime? EncDate { get; set; }

        public NetworkType()
        {

        }

        public void Create(NetworkType networkType)
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("INSERT INTO tbl_NetworkTypes ([Name], [EncBy]) VALUES(@Name,@EncBy);", con);
                cm.Parameters.Add(new SqlParameter("@Name", networkType.Name));
                cm.Parameters.Add(new SqlParameter("@EncBy", session.User.ID));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(NetworkType networkType)
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("UPDATE tbl_NetworkTypes SET [Name]=@Name, [EncBy]=@EncBy;", con);
                cm.Parameters.Add(new SqlParameter("@Name", networkType.Name));
                cm.Parameters.Add(new SqlParameter("@EncBy", networkType.EncBy));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<NetworkType> List(string search="")
        {
            var list = new List<NetworkType>();

            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM tbl_NetworkTypes WHERE Name LIKE @search;", con);
                cm.Parameters.Add(new SqlParameter("@search", $"%{search}%"));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
              

                foreach (DataRow r in dt.Rows)
                {
                    list.Add(new NetworkType
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        Name = Convert.ToString(r["Name"]),
                        EncBy = Convert.ToInt32(r["EncBy"]),
                        EncDate = Convert.ToDateTime(r["EncDate"])
                    });
                }  con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public SelectList NetworkTypes()
        {
            var list = new SelectList(List(), "ID", "Name");
            return list;
        }

        public NetworkType Find(int ID)
        {
            var item = new NetworkType();

            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM tbl_NetworkTypes WHERE ID=@ID;", con);
                cm.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                foreach (DataRow r in dt.Rows)
                {
                    item = new NetworkType
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        Name = Convert.ToString(r["Name"]),
                        EncBy = Convert.ToInt32(r["EncBy"]),
                        EncDate = Convert.ToDateTime(r["EncDate"])
                    };
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public void Delete(int ID)
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("DELETE FROM tbl_NetworkTypes WHERE ID=@ID", con);
                cm.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}