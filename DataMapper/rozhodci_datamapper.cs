using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataMapper
{
   public class rozhodci_datamapper
    {
        public static String SQL_SELECT = "SELECT * FROM \"rozhodci\"";
        public static String SQL_INSERT = "INSERT INTO \"rozhodci\" VALUES (@jmeno, @prijmeni, @datnar, @narodnost," +
            "@licence)";
        public static String SQL_DELETE = "DELETE FROM \"rozhodci\" WHERE idrozhodci=@idrozhodci";
        public static String SQL_UPDATE = "UPDATE \"rozhodci\" SET jmeno=@jmeno, prijmeni=@prijmeni," +
            "datnar=@datnar, narodnost=@narodnost, licence=@licence where idrozhodci=@idrozhodci";
        public static String SQL_DELETE_ALL = "DELETE FROM \"rozhodci\"";
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(rozhodci rozhodci, Database pDb = null)
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
            PrepareCommand(command, rozhodci);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Delete(int idrozhodci, Database pDB = null)
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

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            command.Parameters.AddWithValue("@idrozhodci", idrozhodci);

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

        public static int Update(rozhodci rozhodci, Database pDB = null)
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
            PrepareCommand(command, rozhodci);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static List<rozhodci> Select_vsechny(Database pDB = null)
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

            List<rozhodci> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }


        private static void PrepareCommand(SqlCommand command, rozhodci rozhodci)
        {
            command.Parameters.AddWithValue("@idrozhodci", rozhodci.Idrozhodci);
            command.Parameters.AddWithValue("@jmeno", rozhodci.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", rozhodci.Prijmeni);
            command.Parameters.AddWithValue("@datnar", rozhodci.Datnar);
            command.Parameters.AddWithValue("@narodnost", rozhodci.Narodnost);
            command.Parameters.AddWithValue("@licence", rozhodci.Licence);
        }

        private static List<rozhodci> Read(SqlDataReader dataReader)
        {
            List<rozhodci> list = new List<rozhodci>();

            while (dataReader.Read())
            {
                int i = -1;
                rozhodci rozhodci = new rozhodci();
                rozhodci.Idrozhodci = dataReader.GetInt32(++i);
                rozhodci.Jmeno = dataReader.GetString(++i);
                rozhodci.Prijmeni = dataReader.GetString(++i);
                rozhodci.Datnar = dataReader.GetDateTime(++i);
                rozhodci.Narodnost = dataReader.GetString(++i);
                rozhodci.Licence = dataReader.GetString(++i);

                list.Add(rozhodci);
            }
            return list;
        }
    }
}
