using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataMapper
{
    public class zapas_datamapper
    {
        public static String SQL_SELECT = "SELECT * FROM zapas z join tym t on z.tym_idtym=t.idtym";
        public static String SQL_INSERT = "INSERT INTO \"zapas\" VALUES (@datum, @cas, @stadion_idstadion," +
            "@golydom, @golyhos,@tym_idtym,@tym_idtym1,@pocetdivaku,@rozhodci_idrozhodci,@rozhodci_idrozhodci1,@spravce_idspravce)";
        public static String SQL_UPDATE = "UPDATE \"zapas\" SET datum=@datum, cas=@cas, stadion=@stadion_idstadion," +
            "golydom=@golydom, golyhos=@golyhos,tym_idtym=@tym_idtym,tym_idtym1=@tym_idtym1,pocetdivaku=@pocetdivaku,rozhodci_idrozhodci=@rozhodci_idrozhodci,rozhodci_idrozhodci1=@rozhodci_idrozhodci1,spravce_idspravce=@spravce_idspravce";
        public static String SQL_DELETE = "DELETE FROM \"zapas\" WHERE idzapas=@idzapas";
        public static String SQL_DELETE_ALL = "DELETE FROM \"zapas\"";
        public static String SQL_CanPlay = "SELECT * FROM zapas z join tym t on z.tym_idtym=t.idtym where datum=@datum AND (tym_idtym=@tym_idtym or tym_idtym1=@tym_idtym OR tym_idtym=@tym_idtym1 OR tym_idtym1=@tym_idtym1)";
        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(zapas zapas, Database pDb = null)
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
            PrepareCommand(command, zapas);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        /*
        public static int Insert(String datum, String cas, int ids, int idt, int idt1, int idr, int idr1, int idsp, Database pDb = null)
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
            command.Parameters.AddWithValue("@datum", datum);
            command.Parameters.AddWithValue("@cas", cas);
            command.Parameters.AddWithValue("@stadion_idstadion", ids);
            command.Parameters.AddWithValue("@stadion_idstadion", ids);
            command.Parameters.AddWithValue("@stadion_idstadion", ids);
            command.Parameters.AddWithValue("@stadion_idstadion", ids);
            command.Parameters.AddWithValue("@stadion_idstadion", ids);
            command.Parameters.AddWithValue("@stadion_idstadion", ids);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        */

        public static int Update(zapas zapas, Database pDB = null)
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
            PrepareCommand(command, zapas);

            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static List<zapas> Select_vsechny(Database pDB = null)
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

            List<zapas> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        public static List<zapas> Select_canplay(int tym1,int tym2,String datum,Database pDB = null)
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

            SqlCommand command = db.CreateCommand(SQL_CanPlay);
            command.Parameters.AddWithValue("@tym_idtym", tym1);
            command.Parameters.AddWithValue("@tym_idtym1", tym2);
            command.Parameters.AddWithValue("@datum", datum);
            SqlDataReader dataReader = db.Select(command);

            List<zapas> list = Read(dataReader);
            dataReader.Close();

            if (pDB == null)
            {
                db.Close();
            }

            return list;
        }

        public static int Delete(int idzapas, Database pDB = null)
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
            command.Parameters.AddWithValue("@idzapas", idzapas);

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


        private static void PrepareCommand(SqlCommand command, zapas zapas)
        {
            command.Parameters.AddWithValue("@idzapas", zapas.Idzapas);
            command.Parameters.AddWithValue("@cas", zapas.Cas);
            command.Parameters.AddWithValue("@datum", zapas.Datum);
            command.Parameters.AddWithValue("@stadion", zapas.Stadion_idstadion);
            command.Parameters.AddWithValue("@golydom", zapas.Golydom);
            command.Parameters.AddWithValue("@golyhos", zapas.Golyhos);
            command.Parameters.AddWithValue("@tym_idtym", zapas.Tym_idtym);
            command.Parameters.AddWithValue("@tym_idtym1", zapas.Tym_idtym1);
            command.Parameters.AddWithValue("@pocetdivaku", zapas.Pocetdivaku);
            command.Parameters.AddWithValue("@rozhodci_idrozhodci", zapas.Rozhodci_idrozhodci);
            command.Parameters.AddWithValue("@rozhodci_idrozhodci1", zapas.Rozhodci_idrozhodci1);
            command.Parameters.AddWithValue("@spravce_idspravce", zapas.Spravce_idspravce);
        }

        private static List<zapas> Read(SqlDataReader dataReader)
        {
            List<zapas> list = new List<zapas>();

            while (dataReader.Read())
            {
                int i = -1;

                zapas zapas = new zapas();
                zapas.Idzapas = dataReader.GetInt32(++i);
                zapas.Datum = dataReader.GetDateTime(++i);
                zapas.Cas = dataReader.GetString(++i);
                zapas.Stadion_idstadion = dataReader.GetInt32(++i);
                zapas.Golydom = dataReader.GetInt32(++i);
                zapas.Golyhos = dataReader.GetInt32(++i);
                zapas.Tym_idtym = dataReader.GetInt32(++i);
                zapas.Tym_idtym1 = dataReader.GetInt32(++i);
                zapas.Pocetdivaku = dataReader.GetInt32(++i);
                zapas.Rozhodci_idrozhodci = dataReader.GetInt32(++i);
                zapas.Rozhodci_idrozhodci1 = dataReader.GetInt32(++i);
                zapas.Spravce_idspravce = dataReader.GetInt32(++i);
                list.Add(zapas);
            }
            return list;
        }


        public static int aktualizovatzapas(int @idz, int @pocetdivaku, int @golydom, int @golyhos, Database pDb = null)
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
            SqlCommand command = db.CreateCommand("aktualizovatzapas");

            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = CommandType.StoredProcedure;


            // 3. create input parameters
            SqlParameter input1 = new SqlParameter();
            input1.ParameterName = "@idz";
            input1.DbType = DbType.Int32;
            input1.Value = idz;
            input1.Direction = ParameterDirection.Input;
            command.Parameters.Add(input1);

            SqlParameter input2 = new SqlParameter();
            input2.ParameterName = "@pocetdivaku";
            input2.DbType = DbType.Int32;
            input2.Value = pocetdivaku;
            input2.Direction = ParameterDirection.Input;
            command.Parameters.Add(input2);

            SqlParameter input3 = new SqlParameter();
            input3.ParameterName = "@golydom";
            input3.DbType = DbType.Int32;
            input3.Value = golydom;
            input3.Direction = ParameterDirection.Input;
            command.Parameters.Add(input3);

            SqlParameter input4 = new SqlParameter();
            input4.ParameterName = "@golyhos";
            input4.DbType = DbType.Int32;
            input4.Value = golyhos;
            input4.Direction = ParameterDirection.Input;
            command.Parameters.Add(input4);

            // 4. execute procedure
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }

        public static int novyzapas(String datum, String cas, int ids, int idt, int idt1, int idr, int idr1, int idsp, Database pDb = null)
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
            SqlCommand command = db.CreateCommand("novyzapas");

            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = CommandType.StoredProcedure;


            // 3. create input parameters
            SqlParameter input1 = new SqlParameter();
            input1.ParameterName = "@datum";
            input1.DbType = DbType.String;
            input1.Value = datum;
            input1.Direction = ParameterDirection.Input;
            command.Parameters.Add(input1);

            SqlParameter input2 = new SqlParameter();
            input2.ParameterName = "@cas";
            input2.DbType = DbType.String;
            input2.Value = cas;
            input2.Direction = ParameterDirection.Input;
            command.Parameters.Add(input2);

            SqlParameter input3 = new SqlParameter();
            input3.ParameterName = "@ids";
            input3.DbType = DbType.Int32;
            input3.Value = ids;
            input3.Direction = ParameterDirection.Input;
            command.Parameters.Add(input3);

            SqlParameter input4 = new SqlParameter();
            input4.ParameterName = "@idt";
            input4.DbType = DbType.Int32;
            input4.Value = idt;
            input4.Direction = ParameterDirection.Input;
            command.Parameters.Add(input4);

            SqlParameter input5 = new SqlParameter();
            input5.ParameterName = "@idt1";
            input5.DbType = DbType.Int32;
            input5.Value = idt1;
            input5.Direction = ParameterDirection.Input;
            command.Parameters.Add(input5);

            SqlParameter input6 = new SqlParameter();
            input6.ParameterName = "@idr";
            input6.DbType = DbType.Int32;
            input6.Value = idr;
            input6.Direction = ParameterDirection.Input;
            command.Parameters.Add(input6);

            SqlParameter input7 = new SqlParameter();
            input7.ParameterName = "@idr1";
            input7.DbType = DbType.Int32;
            input7.Value = idr1;
            input7.Direction = ParameterDirection.Input;
            command.Parameters.Add(input7);

            SqlParameter input8 = new SqlParameter();
            input8.ParameterName = "@idsp";
            input8.DbType = DbType.Int32;
            input8.Value = idsp;
            input8.Direction = ParameterDirection.Input;
            command.Parameters.Add(input8);

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

