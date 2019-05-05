using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DBBase.SqliteHelper
{
    class Helper
    {
        //数据库连接字符串(web.config来配置)，可以动态更改SQLString支持多数据库.         
        public static string connectionString = "Data Source=;Version=3;";

        public static SQLiteParameter GetOleDbParameter(string paraName, DbType type, int paraSize, Object value)
        {
            SQLiteParameter para = new SQLiteParameter(paraName, type, paraSize);
            para.Value = value;
            return para;
        }
        public static string GetTableData(string Fields, string ID)
        {
            string Sql = "select " + Fields + " From [table] where id='" + ID + "'";
            return GetData(Sql);
        }

        public static string GetData(string Sql)
        {
            object obj = GetSingle(Sql);
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string strSql, params SQLiteParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

#endregion

        /// <summary>
        /// 保证数据库连接处于打开状态
        /// </summary>
        /// <param name="connection"></param>
        public static void OpenDb(SQLiteConnection connection)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        public static int ExecuteSql(string SQLString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(SQLString, connection))
                {
                    OpenDb(connection);
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        public static int ExecuteSql(string SQLString, string content)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                SQLiteCommand cmd = new SQLiteCommand(SQLString, connection);
                using (cmd)
                {
                    SQLiteParameter myParameter = new SQLiteParameter("@content", DbType.String);
                    myParameter.Value = content;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                using (SQLiteCommand cmd = new SQLiteCommand(SQLString, connection))
                {
                    SQLiteParameter myParameter = new SQLiteParameter("@content", DbType.String);
                    myParameter.Value = content;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                using (SQLiteCommand cmd = new SQLiteCommand(strSQL, connection))
                {
                    SQLiteParameter myParameter = new SQLiteParameter("@fs", DbType.Binary);
                    myParameter.Value = fs;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        public static object GetSingle(string SQLString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                using (SQLiteCommand cmd = new SQLiteCommand(SQLString, connection))
                {
                    try
                    {
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SQLite.SQLiteException e)
                    {
                        //connection.Close();
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        connection.Close();
                        cmd.Dispose();
                    }
                }
            }
        }

        public static DataSet Query(string SQLString)
        {

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                try
                {
                    DataSet ds = new DataSet();
                    using (SQLiteDataAdapter command = new SQLiteDataAdapter(SQLString, connection))
                    {
                        command.Fill(ds, "ds");
                    }
                    return ds;
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        public static DataSet Query(string SQLString, string TableName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                DataSet ds = new DataSet();
                try
                {
                    SQLiteDataAdapter command = new SQLiteDataAdapter(SQLString, connection);
                    using (command)
                    {
                        command.Fill(ds, TableName);
                    }
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;


            }
        }
        public static DataSet Query(string SQLString, int Times)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                DataSet ds = new DataSet();
                try
                {
                    SQLiteDataAdapter command = new SQLiteDataAdapter(SQLString, connection);
                    using (command)
                    {
                        command.SelectCommand.CommandTimeout = Times;
                        command.Fill(ds, "ds");
                    }
                    return ds;
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                }


            }
        }

        public static int ExecuteSql(string SQLString, params SQLiteParameter[] cmdParms)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                OpenDb(connection);
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }
    }
}
