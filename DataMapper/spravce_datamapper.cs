using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataMapper
{
    public class spravce_datamapper
    {
        public static String SQL_SELECT = "SELECT * FROM \"spravce\"";
        public static String SQL_INSERT = "INSERT INTO \"spravce\" VALUES (@jmeno, @prijmeni, @datnar, @kontakt, @heslo, @administrator)";
        public static String SQL_UPDATE = "UPDATE \"spravce\" SET Jmeno=@jmeno, Prijmeni=@prijmeni," +
            "Datnar=@datnar, Kontakt=@kontakt, Heslo=@heslo, Administrator=@administrator where idspravce=@idspravce";
        public static String SQL_DELETE_ALL = "DELETE FROM \"spravce\"";
        public static String SQL_SELECT_BYEMAIL = "SELECT * FROM \"spravce\" where kontakt=@email";
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(spravce spravce, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, spravce);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(spravce spravce, Database pDB = null)
        {
            Database db;
            if (pDB == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDB;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, spravce);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int DeleteAll(Database pDB = null)
        {
            Database db;
            if (pDB == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDB;
            }

            SqlCommand command = db.CreateCommand(SQL_DELETE_ALL);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static List<spravce> Select_vsechny(Database pDB = null)
        {
            Database db;
            if (pDB == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDB;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader dataReader = db.Select(command);

            List<spravce> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        public static List<spravce> Select_byemail(String email,Database pDB = null)
        {
            Database db;
            if (pDB == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDB;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_BYEMAIL);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader dataReader = db.Select(command);

            List<spravce> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }


        private static void PrepareCommand(SqlCommand command, spravce spravce)
        {
            command.Parameters.AddWithValue("@idspravce", spravce.Idspravce);
            command.Parameters.AddWithValue("@jmeno", spravce.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", spravce.Prijmeni);
            command.Parameters.AddWithValue("@datnar", spravce.Datnar);
            command.Parameters.AddWithValue("@kontakt", spravce.Kontakt);
            command.Parameters.AddWithValue("@heslo", spravce.Heslo);
            command.Parameters.AddWithValue("@administrator", spravce.Administrator);
        }

        private static List<spravce> Read(SqlDataReader dataReader)
        {
            List<spravce> list = new List<spravce>();

            while (dataReader.Read())
            {
                int i = -1;
                spravce spravce = new spravce();
                spravce.Idspravce = dataReader.GetInt32(++i);
                spravce.Jmeno = dataReader.GetString(++i);
                spravce.Prijmeni = dataReader.GetString(++i);
                spravce.Datnar = dataReader.GetDateTime(++i);
                spravce.Kontakt = dataReader.GetString(++i);
                spravce.Heslo = dataReader.GetString(++i);
                spravce.Administrator = dataReader.GetString(++i);
                list.Add(spravce);
            }
            return list;
        }
    }
}
