using System;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DataMapper
{
    public class hrac_datamapper
    {
        public static String SQL_SELECT = "SELECT * FROM \"hrac\"";
        public static String SQL_SELECT_ID_tym = "SELECT * FROM \"hrac\" WHERE Tym_idtym=@idtym";
        public static String SQL_SELECT_freedres = "SELECT * FROM \"hrac\" WHERE Tym_idtym=@idtym and cislodres=@cislodres";
        public static String SQL_SELECT_ID_pozice = "SELECT * FROM \"hrac\" WHERE Tym_idtym=@idtym and (Prijmeni=@filtr or Pozice=@filtr)";
        public static String SQL_INSERT = "INSERT INTO \"hrac\" VALUES (@jmeno, @prijmeni, @narodnost, @datnar," +
            "@cislodres, @pozice, @tym)";
        public static String SQL_DELETE = "DELETE FROM \"hrac\" WHERE idhrac=@idhrac";
        public static String SQL_DELETE_ALL = "DELETE FROM \"hrac\"";
        public static String SQL_UPDATE = "UPDATE \"hrac\" SET jmeno=@jmeno, prijmeni=@prijmeni," +
            "narodnost=@narodnost, datnar=@datnar, cislodres=@cislodres," +
            "pozice=@pozice WHERE idhrac=@idhrac";
        
                /// <summary>
                /// Insert the record.
                /// </summary>
                public static int Insert(hrac hrac, Database pDb = null)
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
                    PrepareCommand(command, hrac);
                    int ret = db.ExecuteNonQuery(command);

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return ret;
                }
        public static List<hrac> Select_freedres(int dres,int tym, Database pDB = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_freedres);
            command.Parameters.AddWithValue("@cislodres", dres);
            command.Parameters.AddWithValue("@idtym", tym);
            SqlDataReader dataReader = db.Select(command);

            List<hrac> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }
        public static int Delete(int idhrac, Database pDB = null)
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
            command.Parameters.AddWithValue("@idhrac", idhrac);

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

        public static int Update(hrac hrac, Database pDB = null)
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
            PrepareCommand(command, hrac);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static List<hrac> Select_vsechny(Database pDB = null)
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

            List<hrac> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        public static List<hrac> Select_podletym(int idtym, Database pDB = null)
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

            List<hrac> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        public static List<hrac> Select_filtr(int idtym, string filtr, Database pDB = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_pozice);
            command.Parameters.AddWithValue("@filtr", filtr);
            command.Parameters.AddWithValue("@idtym", idtym);
            SqlDataReader dataReader = db.Select(command);

            List<hrac> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        private static void PrepareCommand(SqlCommand command, hrac hrac)
        {
            command.Parameters.AddWithValue("@idhrac", hrac.Idhrac);
            command.Parameters.AddWithValue("@jmeno", hrac.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", hrac.Prijmeni);
            command.Parameters.AddWithValue("@narodnost", hrac.Narodnost);
            command.Parameters.AddWithValue("@datnar", hrac.Datnar.ToShortDateString());
            command.Parameters.AddWithValue("@cislodres", hrac.Cislodres);
            command.Parameters.AddWithValue("@pozice", hrac.Pozice);
            command.Parameters.AddWithValue("@tym", hrac.Tym_idtym);
        }

        private static List<hrac> Read(SqlDataReader dataReader)
        {
            List<hrac> list = new List<hrac>();

            while (dataReader.Read())
            {
                int i = -1;
                hrac hrac = new hrac();
                hrac.Idhrac = dataReader.GetInt32(++i);
                hrac.Jmeno = dataReader.GetString(++i);
                hrac.Prijmeni = dataReader.GetString(++i);
                hrac.Narodnost = dataReader.GetString(++i);
                hrac.Datnar = dataReader.GetDateTime(++i);
                hrac.Cislodres = dataReader.GetInt32(++i);
                hrac.Pozice = dataReader.GetString(++i);
                hrac.Tym_idtym = dataReader.GetInt32(++i);

                list.Add(hrac);
            }
            return list;
        }

        public static int pridathrace(string jmeno, string prijmeni, string narod, String datna, int cislo, string pozi, int idt, Database pDb = null)
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

            // 1.  create a command object identifying the stored procedure
            SqlCommand command = db.CreateCommand("novyhrac");

            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = CommandType.StoredProcedure;


            // 3. create input parameters
            SqlParameter input1 = new SqlParameter();
            input1.ParameterName = "@jm";
            input1.DbType = DbType.String;
            input1.Value = jmeno;
            input1.Direction = ParameterDirection.Input;
            command.Parameters.Add(input1);

            SqlParameter input2 = new SqlParameter();
            input2.ParameterName = "@prij";
            input2.DbType = DbType.String;
            input2.Value = prijmeni;
            input2.Direction = ParameterDirection.Input;
            command.Parameters.Add(input2);

            SqlParameter input3 = new SqlParameter();
            input3.ParameterName = "@narod";
            input3.DbType = DbType.String;
            input3.Value = narod;
            input3.Direction = ParameterDirection.Input;
            command.Parameters.Add(input3);

            SqlParameter input4 = new SqlParameter();
            input4.ParameterName = "@datna";
            input4.DbType = DbType.String;
            input4.Value = datna;
            input4.Direction = ParameterDirection.Input;
            command.Parameters.Add(input4);

            SqlParameter input5 = new SqlParameter();
            input5.ParameterName = "@cislo";
            input5.DbType = DbType.Int32;
            input5.Value = cislo;
            input5.Direction = ParameterDirection.Input;
            command.Parameters.Add(input5);

            SqlParameter input6 = new SqlParameter();
            input6.ParameterName = "@pozi";
            input6.DbType = DbType.String;
            input6.Value = pozi;
            input6.Direction = ParameterDirection.Input;
            command.Parameters.Add(input6);

            SqlParameter input7 = new SqlParameter();
            input7.ParameterName = "@idt";
            input7.DbType = DbType.Int32;
            input7.Value = idt;
            input7.Direction = ParameterDirection.Input;
            command.Parameters.Add(input7);

            // 4. execute procedure
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }
    }
}
