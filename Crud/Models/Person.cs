using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;



namespace Crud.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }

        string server = @"192.168.0.101\sqlExpress";
        string dataBase = "dbsample";
        string user = "SA";
        string password = "1234";
        string table = "tbl_sample";
        DataTable dt;
        public Person()
        {

        }

        public List<Person> Retrieve(string searchItem="")
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            string cmString;

            if (string.IsNullOrEmpty(searchItem))
            {
                cmString = $"SELECT * FROM {table}";
            }
            else
            {
                cmString = $"SELECT * FROM {table} WHERE CONCAT(fname, mn, lname) LIKE '%{searchItem}%'";
            }

            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");
            try
            {
                con.Open();
                cm = new SqlCommand(cmString, con);
                da = new SqlDataAdapter(cm);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            List<Person> persons = new List<Person>();

            foreach (DataRow obj in dt.Rows)
            {
                persons.Add(new Person() { ID = (int)obj[0], FName = obj[1].ToString(), MName = obj[2].ToString(), LName = obj[3].ToString() });
            }

            return persons;
        }

        public Person Retrieve(int ID)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            string cmString = $"SELECT * FROM {table} WHERE ID = {ID}";
            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");
            try
            {
                con.Open();
                cm = new SqlCommand(cmString, con);
                da = new SqlDataAdapter(cm);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            Person person = new Person();

            foreach (DataRow r in dt.Rows)
            {
                person.ID = (int)r["ID"];
                person.FName = (string)r["fname"];
                person.MName = (string)r["mn"];
                person.LName = (string)r["lname"];
            }

            return person;
        }

        public void Insert(Person person)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;
            
            string headerfname = "fname";
            string headermname = "mn";
            string headerlname = "lname";

            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");

            string cmString =
                $"INSERT INTO {table} ({headerfname},{headermname},{headerlname}) VALUES ('{person.FName}','{person.MName}','{person.LName}')";

            try
            {
                con.Open();
                cm = new SqlCommand(cmString, con);
                da = new SqlDataAdapter(cm);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public void Update(Person person)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;
            
            string headerfname = "fname";
            string headermname = "mn";
            string headerlname = "lname";

            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");

            string cmString =
                $"UPDATE {table} SET {headerfname}='{person.FName}',{headermname}='{person.MName}',{headerlname}='{person.LName}' WHERE ID={person.ID}";

            try
            {
                con.Open();
                cm = new SqlCommand(cmString, con);
                da = new SqlDataAdapter(cm);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(int ID)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");

            string cmString = $"DELETE FROM {table} WHERE ID={ID}";

            try
            {
                con.Open();
                cm = new SqlCommand(cmString);
                da = new SqlDataAdapter(cm.CommandText, con);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }


    }
}