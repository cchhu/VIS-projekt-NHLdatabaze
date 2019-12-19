using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataMapper
{
    public class stadion_datamapper
    {
        public static String SQL_SELECT = "SELECT * FROM \"stadion\"";
        public static String SQL_INSERT = "INSERT INTO \"stadion\" VALUES (@nazev, @kapacita, @mesto, @ulice, @psc)";
        public static String SQL_DELETE = "DELETE FROM \"stadion\" WHERE idstadion=@idstadion";
        public static String SQL_UPDATE = "UPDATE \"stadion\" SET nazev=@nazev, kapacita=@kapacita," +
            "mesto=@mesto, ulice=@ulice, psc=@psc WHERE idstadion=@idstadion";
        public static String SQL_DELETE_ALL = "DELETE FROM \"stadion\"";
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(stadion stadion, Database pDb = null)
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
            PrepareCommand(command, stadion);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Delete(int idstadion, Database pDB = null)
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
            command.Parameters.AddWithValue("@idstadion", idstadion);

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

        public static int Update(stadion stadion, Database pDB = null)
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
            PrepareCommand(command, stadion);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static List<stadion> Select_vsechny(Database pDB = null)
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

            List<stadion> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        private static void PrepareCommand(SqlCommand command, stadion stadion)
        {
            command.Parameters.AddWithValue("@idstadion", stadion.Idstadion);
            command.Parameters.AddWithValue("@nazev", stadion.Nazev);
            command.Parameters.AddWithValue("@kapacita", stadion.Kapacita);
            command.Parameters.AddWithValue("@mesto", stadion.Mesto);
            command.Parameters.AddWithValue("@ulice", stadion.Ulice);
            command.Parameters.AddWithValue("@psc", stadion.Psc);
        }

        private static List<stadion> Read(SqlDataReader dataReader)
        {
            List<stadion> list = new List<stadion>();

            while (dataReader.Read())
            {
                int i = -1;
                stadion stadion = new stadion();
                stadion.Idstadion = dataReader.GetInt32(++i);
                stadion.Nazev = dataReader.GetString(++i);
                stadion.Kapacita = dataReader.GetInt32(++i);
                stadion.Mesto = dataReader.GetString(++i);
                stadion.Ulice = dataReader.GetString(++i);
                stadion.Psc = dataReader.GetString(++i);

                list.Add(stadion);
            }
            return list;
        }


    }
}

