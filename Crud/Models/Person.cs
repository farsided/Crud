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

        public List<Person> Retrieve()
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            string cmString = $"SELECT * FROM {table}";
            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");
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
        public void Insert(string ID, string fname, string mname, string lname)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            string headerID = "ID";
            string headerfname = "fname";
            string headermname = "mn";
            string headerlname = "lname";

            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");

            string cmString =
                $"INSERT INTO {table}({headerID},{headerfname},{headermname},{headerlname}) VALUES({ID},{fname},{mname},{lname})";

            try
            {
                con.Open();
                Console.WriteLine("Success connection from Insert");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed connection from Insert");
                throw e;
            }
            finally
            {
                cm = new SqlCommand(cmString);
                da = new SqlDataAdapter(cm.CommandText, con);
                dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("Fill function from Insert");
                con.Close();
            }
        }

        public void Insert(Person person)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            string headerID = "ID";
            string headerfname = "fname";
            string headermname = "mn";
            string headerlname = "lname";

            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");

            string cmString =
                $"INSERT INTO {table}({headerID},{headerfname},{headermname},{headerlname}) VALUES({person.ID},{person.FName},{person.MName},{person.LName})";

            try
            {
                con.Open();
                Console.WriteLine("Success connection from Insert");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed connection from Insert");
                throw e;
            }
            finally
            {
                cm = new SqlCommand(cmString);
                da = new SqlDataAdapter(cm.CommandText, con);
                dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("Fill function from Insert");
                con.Close();
            }
        }

        public void Update(int ID, string fname, string mname, string lname)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            string headerID = "ID";
            string headerfname = "fname";
            string headermname = "mn";
            string headerlname = "lname";

            con = new SqlConnection($"SERVER={server};DATABASE={dataBase};USER={user};PWD={password}");

            string cmString =
                $"UPDATE {table} SET {headerID}={ID},{headerfname}='{fname}',{headermname}='{mname}',{headerlname}='{lname}' WHERE ID={ID}";

            try
            {
                con.Open();
                Console.WriteLine("Success connection from Update");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed connection from Update");
                throw e;
            }
            finally
            {
                cm = new SqlCommand(cmString);
                da = new SqlDataAdapter(cm.CommandText, con);
                dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("Fill function from Update");
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
                Console.WriteLine("Success connection from Delete");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed connection from Delete");
                throw e;
            }
            finally
            {
                cm = new SqlCommand(cmString);
                da = new SqlDataAdapter(cm.CommandText, con);
                dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("Fill function from Delete");
                con.Close();
            }
        }
    }
}