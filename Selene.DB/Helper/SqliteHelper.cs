using Selence.DB.Ex;
using Selene.DB.Enums;
using Selene.DB.Message;
using Selene.DB.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DB.Helper
{
    public class SqliteHelper : IHelper
    {
        public string _DataMode
        {
            get
            {
                return "Sqlite";
            }
        }

        public DataMode EDataMode
        {
            get
            {
                return Enums.DataMode.Sqlite;
            }
        }

        private SQLiteConnection conn = null;
        public SQLiteConnection Conn
        {
            get
            {
                if (null == conn)
                {
                    var connStr = GetString();
                    conn = new SQLiteConnection(connStr);
                    conn.Open();
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                return conn;
            }
        }

        /// <summary>
        /// 关闭Connection
        /// </summary>
        public void CloseConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public DbConnection GetConnection()
        {
            return this.Conn;
        }
        private string connString;
        public void SetConnString(string connString)
        {
            this.connString = connString;
        }
        public string GetString()
        {
            if (!string.IsNullOrEmpty(connString))
            {
                return connString;
            }
            return DBConfig.ConnString;
        }

        public int ExecuteCommand(string cmdText, CommandType cmdType, List<DbParameter> parms)
        {
            using (SQLiteCommand command = new SQLiteCommand(cmdText, Conn))
            {
                command.CommandType = cmdType;
                if (null != parms) command.Parameters.AddRange(parms.ToArray());
                var result = command.ExecuteNonQuery();
                CloseConn();
                return result;
            }
        }

        public int ExecuteCommand(string cmdText, List<DbParameter> parms)
        {
            return ExecuteCommand(cmdText, CommandType.Text, parms);
        }

        public int ExecuteCommand(string cmdText)
        {
            return ExecuteCommand(cmdText, null);
        }

        public DataTable GetDataTable(string cmdText, CommandType cmdType, List<DbParameter> parms)
        {
            using (SQLiteCommand command = new SQLiteCommand(cmdText, Conn))
            {
                DataSet dataSet = new DataSet();
                command.CommandType = cmdType;
                if (parms != null) command.Parameters.AddRange(parms.ToArray());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataSet);
                //关闭连接
                CloseConn();
                if (dataSet.Tables != null && dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
                return null;
            }
        }

        public DataTable GetDataTable(string cmdText, List<DbParameter> parms)
        {
            return GetDataTable(cmdText, CommandType.Text, parms);
        }

        public DataTable GetDataTable(string cmdText)
        {
            return GetDataTable(cmdText, null);
        }

        public IDataReader GetDataReader(string cmdText, CommandType cmdType, List<DbParameter> parms)
        {
            using (SQLiteCommand command = new SQLiteCommand(cmdText, Conn))
            {
                command.CommandType = cmdType;
                if (parms != null) command.Parameters.AddRange(parms.ToArray());
                return command.ExecuteReader();
            }
        }

        public IDataReader GetDataReader(string cmdText, List<DbParameter> parms)
        {
            return GetDataReader(cmdText, CommandType.Text, parms);
        }

        public IDataReader GetDataReader(string cmdText)
        {
            return GetDataReader(cmdText, null);
        }

        public object GetDataScalar(string cmdText, CommandType cmdType, List<DbParameter> parms)
        {
            using (SQLiteCommand command = new SQLiteCommand(cmdText, Conn))
            {
                command.CommandType = cmdType;
                if (null != parms) command.Parameters.AddRange(parms.ToArray());
                var result = command.ExecuteScalar();
                CloseConn();
                return result;
            }
        }

        public object GetDataScalar(string cmdText, List<DbParameter> parms)
        {
            return GetDataScalar(cmdText, CommandType.Text, parms);
        }

        public object GetDataScalar(string cmdText)
        {
            return GetDataScalar(cmdText);
        }

        public dataType GetDataScalar<dataType>(string cmdText, CommandType cmdType, List<DbParameter> parms)
        {
            object obj = GetDataScalar(cmdText, cmdType, parms);
            if (obj == null)
            {
                if (typeof(dataType) == typeof(int))
                {
                    obj = -1;
                }
                else
                {
                    return default(dataType);
                }
                
            }
            return (dataType)Convert.ChangeType(obj, typeof(dataType));
        }

        public dataType GetDataScalar<dataType>(string cmdText, List<DbParameter> parms)
        {
            return GetDataScalar<dataType>(cmdText, CommandType.Text, parms);
        }

        public dataType GetDataScalar<dataType>(string cmdText)
        {
            return GetDataScalar<dataType>(cmdText, null);
        }

        public DataSet GetDataSet(string cmdText, CommandType cmdType, List<DbParameter> parms)
        {
            using (SQLiteCommand command = new SQLiteCommand(cmdText, Conn))
            {
                DataSet dataSet = new DataSet();
                command.CommandType = cmdType;
                if (parms != null) command.Parameters.AddRange(parms.ToArray());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataSet);
                //关闭连接
                CloseConn();

                return dataSet;
            }
        }

        public DataSet GetDataSet(string cmdText, List<DbParameter> parms)
        {
            return GetDataSet(cmdText, CommandType.Text, parms);
        }

        public DataSet GetDataSet(string cmdText)
        {
            return GetDataSet(cmdText, null);
        }

        public bool BatchInsert(DataTable dt)
        {
            throw new Exception("not support; SqliteHelper BatchInsert throw");
        }

        #region Query

        private List<DbParameter> GetParametersList(Dictionary<string, object> dicParameters)
        {
            List<DbParameter> lst = new List<DbParameter>();
            if (dicParameters != null)
            {
                foreach (KeyValuePair<string, object> kv in dicParameters)
                {
                    lst.Add(new SQLiteParameter(kv.Key, kv.Value));
                }
            }
            return lst;
        }

        public string Escape(string data)
        {
            data = data.Replace("'", "''");
            data = data.Replace("\\", "\\\\");
            return data;
        }

        public int Insert(string tableName, Dictionary<string, object> dic)
        {
            StringBuilder sbCol = new System.Text.StringBuilder();
            StringBuilder sbVal = new System.Text.StringBuilder();

            foreach (KeyValuePair<string, object> kv in dic)
            {
                if (sbCol.Length == 0)
                {
                    sbCol.Append("insert into ");
                    sbCol.Append(tableName);
                    sbCol.Append("(");
                }
                else
                {
                    sbCol.Append(",");
                }

                sbCol.Append("`");
                sbCol.Append(kv.Key);
                sbCol.Append("`");

                if (sbVal.Length == 0)
                {
                    sbVal.Append(" values(");
                }
                else
                {
                    sbVal.Append(", ");
                }

                sbVal.Append("@v");
                sbVal.Append(kv.Key);
            }

            sbCol.Append(") ");
            sbVal.Append(");");

            String cmdText = sbCol.ToString() + sbVal.ToString();


            List<DbParameter> parms = new List<DbParameter>();
            foreach (KeyValuePair<string, object> kv in dic)
            {
                parms.Add(new SQLiteParameter("@v" + kv.Key, kv.Value));
            }

            return ExecuteCommand(cmdText, parms);
        }

        public int Insert<TEntity>(Dictionary<string, object> dic)
        {
            string tableName=DBUtil.GetTableName<TEntity>();
            return Insert(tableName, dic);
        }

        public int Update(string tableName, Dictionary<string, object> dicData, string colCond, object varCond)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic[colCond] = varCond;
            return Update(tableName, dicData, dic);
        }

        public int Update<TEntity>(Dictionary<string, object> dicData, string colCond, object varCond)
        {
            string tableName = DBUtil.GetTableName<TEntity>();
            return Update(tableName,dicData,colCond,varCond);
        }

        public int Update(string tableName, Dictionary<string, object> dicData, Dictionary<string, object> dicCond)
        {
            if (dicData.Count == 0)
                throw new Exception("dicData is empty.");

            StringBuilder sbData = new StringBuilder();

            Dictionary<string, object> _dicTypeSource = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> kv1 in dicData)
            {
                _dicTypeSource[kv1.Key] = null;
            }

            foreach (KeyValuePair<string, object> kv2 in dicCond)
            {
                if (!_dicTypeSource.ContainsKey(kv2.Key))
                    _dicTypeSource[kv2.Key] = null;
            }

            sbData.Append("update `");
            sbData.Append(tableName);
            sbData.Append("` set ");

            bool firstRecord = true;

            foreach (KeyValuePair<string, object> kv in dicData)
            {
                if (firstRecord)
                    firstRecord = false;
                else
                    sbData.Append(",");

                sbData.Append("`");
                sbData.Append(kv.Key);
                sbData.Append("` = ");

                sbData.Append("@v");
                sbData.Append(kv.Key);
            }

            sbData.Append(" where ");

            firstRecord = true;

            foreach (KeyValuePair<string, object> kv in dicCond)
            {
                if (firstRecord)
                    firstRecord = false;
                else
                {
                    sbData.Append(" and ");
                }

                sbData.Append("`");
                sbData.Append(kv.Key);
                sbData.Append("` = ");

                sbData.Append("@c");
                sbData.Append(kv.Key);
            }

            sbData.Append(";");

            String cmdText = sbData.ToString();

            List<DbParameter> parms = new List<DbParameter>();
            foreach (KeyValuePair<string, object> kv in dicData)
            {
                parms.Add(new SQLiteParameter("@v" + kv.Key, kv.Value));
            }

            foreach (KeyValuePair<string, object> kv in dicCond)
            {
                parms.Add(new SQLiteParameter("@v" + kv.Key, kv.Value));
            }

            return ExecuteCommand(cmdText, parms);
        }

        public int Update<TEntity>(Dictionary<string, object> dicData, Dictionary<string, object> dicCond)
        {
            string tableName = DBUtil.GetTableName<TEntity>();
            return Update(tableName, dicData, dicCond);
        }

        public int LastInsertRowId()
        {
            return GetDataScalar<int>("select last_insert_rowid();");
        }

        public DataTable Select(string sql)
        {
            return GetDataTable(sql, null);
        }

        public DataTable Select(string sql, Dictionary<string, object> dicParameters = null)
        {
            List<DbParameter> lst = GetParametersList(dicParameters);
            return Select(sql, lst);
        }

        public DataTable Select(string sql, List<DbParameter> parameters)
        {
            return GetDataTable(sql, parameters);
        }
        #endregion

        #region Utilities

        public int CreateTable(SQLiteTable table)
        {
            StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("create table if not exists `");
            sb.Append(table.TableName);
            sb.AppendLine("`(");

            bool firstRecord = true;

            foreach (SQLiteColumn col in table.Columns)
            {
                if (col.ColumnName.Trim().Length == 0)
                {
                    throw new Exception("Column name cannot be blank.");
                }

                if (firstRecord)
                    firstRecord = false;
                else
                    sb.AppendLine(",");

                sb.Append(col.ColumnName);
                sb.Append(" ");

                if (col.AutoIncrement)
                {

                    sb.Append("integer primary key autoincrement");
                    continue;
                }

                switch (col.ColDataType)
                {
                    case ColType.Text:
                        sb.Append("text"); break;
                    case ColType.Integer:
                        sb.Append("integer"); break;
                    case ColType.Decimal:
                        sb.Append("decimal"); break;
                    case ColType.DateTime:
                        sb.Append("datetime"); break;
                    case ColType.BLOB:
                        sb.Append("blob"); break;
                    case ColType.Boolean:
                        sb.Append("boolean"); break;
                }

                if (col.PrimaryKey)
                    sb.Append(" primary key");
                else if (col.NotNull)
                    sb.Append(" not null");
                else if (col.DefaultValue.Length > 0)
                {
                    sb.Append(" default ");

                    if (col.DefaultValue.Contains(" ") || col.ColDataType == ColType.Text || col.ColDataType == ColType.DateTime)
                    {
                        sb.Append("'");
                        sb.Append(col.DefaultValue);
                        sb.Append("'");
                    }
                    else
                    {
                        sb.Append(col.DefaultValue);
                    }
                }
            }

            sb.AppendLine(");");

            return ExecuteCommand(sb.ToString());
        }

        public int RenameTable(string tableFrom, string tableTo)
        {
            String cmdText = string.Format("alter table `{0}` rename to `{1}`;", tableFrom, tableTo);
            return ExecuteCommand(cmdText);
        }

        

        public int CopyAllData(string tableFrom, string tableTo)
        {
            DataTable dt1 = Select(string.Format("select * from `{0}` where 1 = 2;", tableFrom));
            DataTable dt2 = Select(string.Format("select * from `{0}` where 1 = 2;", tableTo));

            Dictionary<string, bool> dic = new Dictionary<string, bool>();

            foreach (DataColumn dc in dt1.Columns)
            {
                if (dt2.Columns.Contains(dc.ColumnName))
                {
                    if (!dic.ContainsKey(dc.ColumnName))
                    {
                        dic[dc.ColumnName] = true;
                    }
                }
            }

            foreach (DataColumn dc in dt2.Columns)
            {
                if (dt1.Columns.Contains(dc.ColumnName))
                {
                    if (!dic.ContainsKey(dc.ColumnName))
                    {
                        dic[dc.ColumnName] = true;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, bool> kv in dic)
            {
                if (sb.Length > 0)
                    sb.Append(",");

                sb.Append("`");
                sb.Append(kv.Key);
                sb.Append("`");
            }

            StringBuilder sb2 = new StringBuilder();
            sb2.Append("insert into `");
            sb2.Append(tableTo);
            sb2.Append("`(");
            sb2.Append(sb.ToString());
            sb2.Append(") select ");
            sb2.Append(sb.ToString());
            sb2.Append(" from `");
            sb2.Append(tableFrom);
            sb2.Append("`;");

            return ExecuteCommand(sb2.ToString());
        }

        public int DropTable(string table)
        {
            string cmdText = string.Format("drop table if exists `{0}`", table);
            return ExecuteCommand(cmdText);
        }

        public void UpdateTableStructure(string targetTable, SQLiteTable newStructure)
        {
            newStructure.TableName = targetTable + "_temp";

            CreateTable(newStructure);

            CopyAllData(targetTable, newStructure.TableName);

            DropTable(targetTable);

            RenameTable(newStructure.TableName, targetTable);
        }

        public int AttachDatabase(string database, string alias)
        {
            return ExecuteCommand(string.Format("attach '{0}' as {1};", database, alias));
        }

        public int DetachDatabase(string alias)
        {
            return ExecuteCommand(string.Format("detach {0};", alias));
        }

        #endregion


        #region DB Info

        public DataTable GetTableStatus()
        {
            return Select("SELECT * FROM sqlite_master;");
        }

        public DataTable GetTableList()
        {
            DataTable dt = GetTableStatus();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Tables");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string t = dt.Rows[i]["name"] + "";
                if (t != "sqlite_sequence")
                    dt2.Rows.Add(t);
            }
            return dt2;
        }

        public DataTable GetColumnStatus(string tableName)
        {
            return Select(string.Format("PRAGMA table_info(`{0}`);", tableName));
        }

        public DataTable ShowDatabase()
        {
            return Select("PRAGMA database_list;");
        }

        #endregion
    }
}
