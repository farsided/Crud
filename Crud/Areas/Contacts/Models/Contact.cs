using PMSRedirect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Areas.Contacts.Models
{
    public class Contact
    {
        UserSessions session = new UserSessions();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Contact"].ConnectionString);
        //-------------------------------------------------------------------------------
        public int ID { get; set; }
        public int EID { get; set; }
        public string NetworkNo { get; set; }
        public int NetworkTypeID { get; set; }
        public string BinCard { get; set; }
        public string Remarks { get; set; }
        public int EncBy { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EncDate { get; set; }

        public Contact() { }

        public void Create(Contact contact)
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("INSERT INTO tbl_Contacts (EID, NetworkNo, NetworkTypeID, BinCard, Remarks, EncBy, LastModifiedBy, LastModifiedDate) VALUES (@EID, @NetworkNo, @NetworkTypeID, @BinCard, @Remarks, @encBy, @LastModifiedBy, @LastModifiedDate)", con);
                cm.Parameters.Add(new SqlParameter("@EID", contact.EID));
                cm.Parameters.Add(new SqlParameter("@NetworkNo", contact.NetworkNo));
                cm.Parameters.Add(new SqlParameter("@NetworkTypeID", contact.NetworkTypeID));
                cm.Parameters.Add(new SqlParameter("@BinCard", contact.BinCard));
                cm.Parameters.Add(new SqlParameter("@Remarks", contact.Remarks));
                cm.Parameters.Add(new SqlParameter("@EncBy", session.User.ID));
                cm.Parameters.Add(new SqlParameter("@LastModifiedBy", session.User.ID));
                cm.Parameters.Add(new SqlParameter("@LastModifiedDate", DateTime.Now));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public void Update(Contact contact)
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("UPDATE tbl_Contacts SET EID=@EID, NetworkNo=@NetworkNo, NetworkTypeID=@NetworkTypeID, BinCard=@BinCard, Remarks=@Remarks, LastModifiedBy=@LastModifiedBy, LastModifiedDate=@LastModifiedDate WHERE ID=@ID", con);
                cm.Parameters.Add(new SqlParameter("@ID", contact.ID));
                cm.Parameters.Add(new SqlParameter("@EID", contact.EID));
                cm.Parameters.Add(new SqlParameter("@NetworkNo", contact.NetworkNo));
                cm.Parameters.Add(new SqlParameter("@NetworkTypeID", contact.NetworkTypeID));
                cm.Parameters.Add(new SqlParameter("@BinCard", contact.BinCard));
                cm.Parameters.Add(new SqlParameter("@Remarks", contact.Remarks));
                cm.Parameters.Add(new SqlParameter("@LastModifiedBy", session.User.ID));
                cm.Parameters.Add(new SqlParameter("@LastModifiedDate", DateTime.Now));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public SelectList ListEmployee()
        {
            var list = new List<object>();
            session.User?.List().ForEach(r =>
            {
                if (!string.IsNullOrEmpty(r.Info?.Fullname))
                {
                    list.Add(new
                    {
                        ID = r.Info?.ID,
                        Fullname = r.Info?.Fullname
                    });
                }
            });
            var outputs = new SelectList(list, "ID", "Fullname");
            return outputs;
        }

        public List<Contact> List(string search="")
        {
            var list = new List<Contact>();

            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM tbl_Contacts WHERE NetworkNo LIKE @search", con);
                cm.Parameters.Add(new SqlParameter("@search", $"%{search}%"));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                foreach (DataRow r in dt.Rows)
                {
                    list.Add(new Contact
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        EID = Convert.ToInt32(r["EID"]),
                        NetworkNo = Convert.ToString(r["NetworkNo"]),
                        NetworkTypeID = Convert.ToInt32(r["NetworkTypeID"]),
                        BinCard = Convert.ToString(r["BinCard"]),
                        Remarks = Convert.ToString(r["Remarks"]),
                        EncBy = Convert.ToInt32(r["EncBy"]),
                        LastModifiedBy = Convert.ToInt32(r["LastModifiedBy"]),
                        LastModifiedDate = Convert.ToDateTime(r["LastModifiedDate"]),
                        EncDate = Convert.ToDateTime(r["EncDate"])
                    });
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
            return list;
        }

        public Contact Find(int ID)
        {
            var item = new Contact();

            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM tbl_Contacts WHERE ID=@ID", con);
                cm.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                foreach (DataRow r in dt.Rows)
                {
                    item = new Contact
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        EID = Convert.ToInt32(r["EID"]),
                        NetworkNo = Convert.ToString(r["NetworkNo"]),
                        NetworkTypeID = Convert.ToInt32(r["NetworkTypeID"]),
                        BinCard = Convert.ToString(r["BinCard"]),
                        Remarks = Convert.ToString(r["Remarks"]),
                        EncBy = Convert.ToInt32(r["EncBy"]),
                        LastModifiedBy = Convert.ToInt32(r["LastModifiedBy"]),
                        LastModifiedDate = Convert.ToDateTime(r["LastModifiedDate"]),
                        EncDate = Convert.ToDateTime(r["EncDate"])
                    };
                }
            }
            catch(Exception e)
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
                SqlCommand cm = new SqlCommand("DELETE FROM tbl_Contacts WHERE ID=@ID", con);
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

