using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataMapper
{
    class zamestnanec_datamapper
    {
        public static String SQL_SELECT = "SELECT * FROM \"zamestnanec\"";
        public static String SQL_SELECT_ID_tym = "SELECT * FROM \"zamestnanec\" WHERE Tym_idtym=@idtym";
        public static String SQL_INSERT = "INSERT INTO \"zamestnanec\" VALUES (@jmeno, @prijmeni, @datnar, @prace,@Tym_idtym)";
        public static String SQL_DELETE = "DELETE FROM \"zamestnanec\" WHERE idzamestnanec=@idzamestnanec";
        public static String SQL_UPDATE = "UPDATE \"zamestnanec\" SET jmeno=@jmeno, prijmeni=@prijmeni," +
            "datnar=@datnar, prace=@prace," +
            "Tym_idtym=@tym_idtym";
        public static String SQL_DELETE_ALL = "DELETE FROM \"zamestnanec\"";
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(zamestnanec zamestnanec, Database pDb = null)
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
            PrepareCommand(command, zamestnanec);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Delete(int idzamestnanec, Database pDB = null)
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
            command.Parameters.AddWithValue("@idzamestnanec", idzamestnanec);

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

        public static int Update(zamestnanec zamestnanec, Database pDB = null)
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
            PrepareCommand(command, zamestnanec);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static List<zamestnanec> Select_vsechny(Database pDB = null)
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

            List<zamestnanec> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        public static List<zamestnanec> Select_podletymu(int idtym, Database pDB = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_tym);
            command.Parameters.AddWithValue("@idtym", idtym);
            SqlDataReader dataReader = db.Select(command);

            List<zamestnanec> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }


        private static void PrepareCommand(SqlCommand command, zamestnanec zamestnanec)
        {
            command.Parameters.AddWithValue("@idzamestnanec", zamestnanec.Idzamestnanec);
            command.Parameters.AddWithValue("@jmeno", zamestnanec.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", zamestnanec.Prijmeni);
            command.Parameters.AddWithValue("@datnar", zamestnanec.Datnar);
            command.Parameters.AddWithValue("@prace", zamestnanec.Prace);
            command.Parameters.AddWithValue("@tym", zamestnanec.Tym_idtym);
        }

        private static List<zamestnanec> Read(SqlDataReader dataReader)
        {
            List<zamestnanec> list = new List<zamestnanec>();

            while (dataReader.Read())
            {
                int i = -1;
                zamestnanec zamestnanec = new zamestnanec();
                zamestnanec.Idzamestnanec = dataReader.GetInt32(++i);
                zamestnanec.Jmeno = dataReader.GetString(++i);
                zamestnanec.Prijmeni = dataReader.GetString(++i);
                zamestnanec.Datnar = dataReader.GetDateTime(++i);
                zamestnanec.Prace = dataReader.GetString(++i);
                zamestnanec.Tym_idtym = dataReader.GetInt32(++i);

                list.Add(zamestnanec);
            }
            return list;
        }


    }
}

