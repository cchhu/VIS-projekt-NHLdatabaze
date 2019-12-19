using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataMapper
{
    public class tym_datamapper
    {
        public static String SQL_SELECT = "SELECT * FROM \"tym\"";
        public static String SQL_INSERT = "INSERT INTO \"tym\" VALUES (@nazev, @rokvzniku)";
        public static String SQL_UPDATE = "UPDATE \"tym\" SET Nazev=@nazev, Rokvzniku=@rokvzniku where idtym=@idtym";
        public static String SQL_DELETE = "DELETE FROM \"tym\" WHERE idtym=@idtym";
        public static String statistika = "statistika";
        public static String poslednizapasy = "lastmatches @team_id";
        public static String SQL_DELETE_ALL = "DELETE FROM \"tym\"";
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(tym tym, Database pDb = null)
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
            PrepareCommand(command, tym);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(tym tym, Database pDB = null)
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
            PrepareCommand(command, tym);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Delete(int idtym, Database pDB = null)
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
            command.Parameters.AddWithValue("@idtym", idtym);
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

        public static List<tym> Select_vsechny(Database pDB = null)
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

            List<tym> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        public static String pomocna = "SELECT * FROM \"stat\"";
        public static List<string> stat(Database pDB = null)
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

            SqlCommand command = db.CreateCommand(statistika);
            command.CommandType = CommandType.StoredProcedure;

            SqlCommand com = db.CreateCommand(pomocna);
            SqlDataReader dataReader = db.Select(com);
            List<string> list = Pom(dataReader);
            dataReader.Close();


            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }


        public static String pomocna2 = "SELECT * FROM \"stat_t\"";
        public static List<string> lastmatches(int tymid, Database pDB = null)
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

            SqlCommand command = db.CreateCommand(poslednizapasy);
            command.Parameters.AddWithValue("@team_id", tymid);
            command.CommandType = CommandType.StoredProcedure;

            SqlCommand com = db.CreateCommand(pomocna2);
            SqlDataReader dataReader = db.Select(com);
            List<string> list = Pom(dataReader);
            dataReader.Close();


            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }




        private static void PrepareCommand(SqlCommand command, tym tym)
        {
            command.Parameters.AddWithValue("@idtym", tym.Idtym);
            command.Parameters.AddWithValue("@nazev", tym.Nazev);
            command.Parameters.AddWithValue("@rokvzniku", tym.Rokvzniku);
        }


        private static List<string> Pom(SqlDataReader dataReader)
        {
            List<string> list = new List<string>();

            while (dataReader.Read())
            {
                int i = -1;
                string a;
                a = dataReader.GetString(++i);

                list.Add(a);
            }
            return list;
        }



        private static List<tym> Read(SqlDataReader dataReader)
        {
            List<tym> list = new List<tym>();

            while (dataReader.Read())
            {
                int i = -1;
                tym tym = new tym();
                tym.Idtym = dataReader.GetInt32(++i);
                tym.Nazev = dataReader.GetString(++i);
                if (!dataReader.IsDBNull(++i))
                {
                    --i;
                    tym.Rokvzniku = dataReader.GetString(++i);
                }
                else
                {
                    tym.Rokvzniku = "0000";
                }




                list.Add(tym);
            }
            return list;
        }

    }

}

