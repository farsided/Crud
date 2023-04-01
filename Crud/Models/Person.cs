#define HOME
//#define WORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;



namespace Crud.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Middle Name")]
        public string MName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
#if HOME
        string server = @"(localdb)\MSSQLLocalDB";
        bool integratedSecurity = true;
#elif WORK
        string server = @"192.168.0.101\sqlExpress";
        string user = "SA";
        string password = "1234";
#else
#endif
        string dataBase = "dbsample";
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
                cmString = $"SELECT * FROM {table} WHERE CONCAT(fname, mn, lname) LIKE '%'+@searchItem+'%'";
            }

            con = new SqlConnection($@"SERVER={server};DATABASE={dataBase};" +
                #if HOME
                    $"INTEGRATED SECURITY={integratedSecurity};");
                #elif WORK
                $";USER={user};PWD={password}");
                #else
                #endif

            try
            {
                con.Open();
                cm = new SqlCommand(cmString, con);
                cm.Parameters.AddWithValue("@searchItem", searchItem);
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
                persons.Add(new Person() { ID = (int)obj["ID"], FName = obj["fname"].ToString(), MName = obj["mn"].ToString(), LName = obj["lname"].ToString() });
            }

            return persons;
        }

        public Person Retrieve(int ID)
        {
            SqlConnection con;
            SqlCommand cm;
            SqlDataAdapter da;

            string cmString = $"SELECT * FROM {table} WHERE ID = {ID}";

            con = new SqlConnection($@"SERVER={server};DATABASE={dataBase};" +
                #if HOME
                    $"INTEGRATED SECURITY={integratedSecurity};");
                #elif WORK
                $";USER={user};PWD={password}");
                #else
                #endif

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
                if (!string.IsNullOrEmpty(person.MName)) {
                    person.MName = (string)r["mn"];
                }
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

            con = new SqlConnection($@"SERVER={server};DATABASE={dataBase};" +
                #if HOME
                    $"INTEGRATED SECURITY={integratedSecurity};");
#elif WORK
                        $";USER={user};PWD={password}");
#else
#endif

            string cmString =
                $@"INSERT INTO {table} ({headerfname},";
                if (!string.IsNullOrEmpty(person.MName)) {
                    cmString += $"{headermname},";
                }
                cmString += $"{headerlname}) VALUES (@FName, ";
                if (!string.IsNullOrEmpty(person.MName))
                {
                    cmString += $"@MName,";
                }
                cmString += $"@LName)";

            try
            {
                con.Open();
                cm = new SqlCommand(cmString, con);
                cm.Parameters.Add("@FName", SqlDbType.VarChar).Value = person.FName;
                if (!string.IsNullOrEmpty(person.MName))
                {
                    cm.Parameters.Add("@MName", SqlDbType.NVarChar).Value = person.MName;
                }
                cm.Parameters.Add("@LName", SqlDbType.VarChar).Value = person.LName;
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

            con = new SqlConnection($@"SERVER={server};DATABASE={dataBase};" +
                #if HOME
                    $"INTEGRATED SECURITY={integratedSecurity};");
                #elif WORK
                    $";USER={user};PWD={password}");
                #else
                #endif

            string cmString =
                $"UPDATE {table} SET {headerfname}=@FName,{headerlname}=@LName";
                if (!string.IsNullOrEmpty(person.MName))
                {
                    cmString += $",{headermname}=@MName";
                }
                cmString += $" WHERE ID={person.ID}";

            try
            {
                con.Open();
                cm = new SqlCommand(cmString, con);
                cm.Parameters.AddWithValue("@FName", person.FName);
                if (!string.IsNullOrEmpty(person.MName))
                {
                    cm.Parameters.Add("@MName", SqlDbType.NVarChar);
                    cm.Parameters["@MName"].Value = person.MName;
                }
                cm.Parameters.AddWithValue("@LName", person.LName);
                cm.Parameters.AddWithValue("@ID", person.ID);
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

            con = new SqlConnection($@"SERVER={server};DATABASE={dataBase};" +
                #if HOME
                    $"INTEGRATED SECURITY={integratedSecurity};");
                #elif WORK
                $";USER={user};PWD={password}");
                #else
                #endif

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

        public string GetFullName() {

            return (FName + " " + ( (string.IsNullOrWhiteSpace(MName)) ? "" : MName + " ") + LName );

        }

    }
}