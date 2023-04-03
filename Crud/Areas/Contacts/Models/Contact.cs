using PMSRedirect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
        }
        public void Update(Contact contact)
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
        }

        public List<Contact> List(string search="")
        {
            var list = new List<Contact>();

            con.Open();
            SqlCommand cm = new SqlCommand("SELECT * FROM tbl_Contacts WHERE NetworkNo LIKE @search", con);
            cm.Parameters.Add(new SqlParameter("@search", $"%{search}%"));
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow r in dt.Rows)
            { 
                list.Add(new Contact
                {
                    ID = Convert.ToInt32(r["ID"]), 
                    EID = Convert.ToInt32(r["EID"]),

                });
            }
            return list;
        }
    }
}

